using System;
using BC = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using ICABAPI.Constants;
using ICABAPI.DTOs;
using ICABAPI.DTOs.AdminDto;
using ICABAPI.DTOs.AuthModels;
using ICABAPI.Helpers;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using ICABAPI.Roles;
using ICABAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ICABAPI.DTOs.Decoder;

namespace ICABAPI.Controllers
{
    // [Authorize]
    public class AuthenticateController : BaseApiAdminController
    {
        public class UserAccessRequest
        {
            public string UserId { get; set; }
        }
        public class MainMenus
        {
            public MainMenus()
            {
                subMenu = new List<SubMenus>();
            }
            public int mainMenuId { get; set; }
            public string menusNames { get; set; }
            public List<SubMenus> subMenu { get; set; }



        }
        public class SubMenus
        {
            public int SubMenuId { get; set; }
            public string SUBMENUNAME { get; set; }
            public bool Selected { get; set; }
            public int MainMenuId { get; set; }
            public string ApplicationUserId { get; set; }
        }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        private readonly ITokenService _toeknServe;
        private readonly ModelContext _context;
        public string GlobalRoleId { get; set; }
        private readonly IMapper _mapper;

        private readonly ILogger<AuthenticateController> _logger;
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService toeknServe,
        ModelContext context, IMapper mapper, ILogger<AuthenticateController> logger, IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
            _logger = logger;

            _mapper = mapper;
            _context = context;
            _toeknServe = toeknServe;



            _roleManager = roleManager;
            _userManager = userManager;

        }

        /// <summary>
        /// Create New Decoder
        /// </summary>
        //[Authorize(Roles="SuperAdmin")]
        [HttpPost("decoder-signup")]
        public async Task<ActionResult<SignUpResponse>> DecoderSignUp([FromBody] SignUpRequest signUpRequest)
        {
            var userExist = await _context.DecoderUsers.FirstOrDefaultAsync(u => u.EMAIL == signUpRequest.EMAIL);
            if (userExist != null)
                return BadRequest(new { Status = "error", Message = "user with same email already exist in the system" });
            //  using var hmac = new HMACSHA512();
            DecoderUser user = new DecoderUser()
            {
                NAME = signUpRequest.NAME,
                EMAIL = signUpRequest.EMAIL,
                // PASSWORDHASH =hmac.ComputeHash(Encoding.UTF8.GetBytes(signUpRequest.PASSWORD)),
                // PASSWORDSALT = hmac.Key,
                DESIGNATION = signUpRequest.MOBILE

            };
            user.TOKENVALUE = _toeknServe.CreateTokenDecoder(user);
            signUpRequest.TokenValue = user.TOKENVALUE;
            await _context.DecoderUsers.AddAsync(user);
            var isCreated = await _context.SaveChangesAsync() > 0;
            if (!isCreated)
                return BadRequest(new { status = "error", Messgae = "decoder creation failed,try again" });
            _authenticateService.DecoderRegister(signUpRequest, Request.Headers["origin"]);


            return new SignUpResponse
            {
                Name = user.NAME,
                Message = "a link has been sent to your email,please verify ",
                Error = null


            };
        }

        /// <summary>
        /// Verify Decoder Email
        /// </summary>
        [HttpPost("decoder-verify-email")]
        public async Task<IActionResult> DecoderVerifyEmail([FromBody] DecoderVerifyEmailRequest model)
        {
            var account = await _context.DecoderUsers.FirstOrDefaultAsync(u => u.TOKENVALUE == model.Token && u.EMAILVERIFIED == false);
            if (account == null)
                return BadRequest(new { status = "error", Message = "user not exist/wrong token " });
            if (account.EMAILVERIFIED)
                return BadRequest(new { Status = "error", Message = "email already verified " });

            using var hmac = new HMACSHA512();

            account.TOKENVALUE = null;
            account.EMAILVERIFIED = true;
            account.PASSWORDHASH = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            account.PASSWORDSALT = hmac.Key;


            var verifiedUser = _context.DecoderUsers.Update(account);
            var isUpdated = _context.SaveChanges() > 0;
            if (!isUpdated)
                return BadRequest(new { status = "error", LoggerMessage = "failed to update" });
            return Ok(new { Status = "success", Message = "password created and user verification done" });


        }

        /// <summary>
        /// Create New User (Admin)
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            _logger.LogInformation("begin of registration");
            var userExist = await _userManager.FindByNameAsync(model.Username);
            if (userExist != null)
                return BadRequest(new Response { Status = "error", Message = "user already exists" });
            ApplicationUser user = new ApplicationUser()
            {
                FullName = model.FullName,
                Email = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
            };
            user.TokenValue = await _toeknServe.CreateTokenAdmin(user);
            model.TokenValue = user.TokenValue;
            // var defaultPass ="123Pa$$word!";
            // model.Password = defaultPass;

            var userCreated = await _userManager.CreateAsync(user);
            //var userCreated = await _userManager.CreateAsync(user,model.Password);

            if (!userCreated.Succeeded)
                return BadRequest(new Response { Status = "failed", Message = "User creation failed! Please check user details and try again." });
            // if (userCreated.Succeeded)
            // {
            //     _authenticateService.Register(model, Request.Headers["origin"]);
            // }
            _authenticateService.Register(model, Request.Headers["origin"]);
            return Ok(new Response { Status = "success", Message = "user created successfully ,Registration successful, please check your email for verification instructions" });
        }

        /// <summary>
        /// Verify Email (Admin)
        /// </summary>
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] RegisterModelForEmailVerify model)
        {
            var account = await _context.Users.SingleOrDefaultAsync(a => a.TokenValue == model.TokenValue);
            if (account == null)
                return BadRequest(new { Message = "verification failed" });
            account.TokenValue = null;
            account.EmailConfirmed = true;
            var userId = account.Id;
            var user = await _userManager.FindByIdAsync(userId);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return BadRequest(new Response { Status = "failed", Message = error.Description });
                }

            }
            // if(!result.Succeeded)
            // return BadRequest(new Response { Status = "failed", Message = "User verification failed! Please check user details and try again." });
            var makeUserVerified = _context.Users.Update(account);
            return Ok(new { Status = "success", Message = "password created and user verification done" });




        }

        /// <summary>
        /// User with access
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("userwith-access")]
        public async Task<IActionResult> GetUserWithAccess(UserAccessRequest userAccessRequest)
        {
            var allMenuSubmenus = await _context.MainMenus.Include(s => s.SubMenus).ToListAsync();
            var menuWithSubMenus = allMenuSubmenus.Select(s => new MainMenus()
            {
                mainMenuId = s.ID,
                menusNames = s.MENUNAME,
                subMenu = s.SubMenus.Select(p => new SubMenus()
                {
                    SUBMENUNAME = p.SUBMENUNAME,
                    SubMenuId = p.ID,
                    MainMenuId = s.ID,
                    ApplicationUserId = userAccessRequest.UserId,
                    Selected = false

                }).ToList()
            }).ToList();
            // var allMenuSubmapped = allMenuSubmenus.Select(s =>new{
            //     mainMenuId = s.ID,
            //     menusNames= s.MENUNAME,
            //     subMenu = s.SubMenus.Select(p =>new SubMenus{
            //         SubMenuId= p.ID,
            //         SUBMENUNAME = p.SUBMENUNAME,
            //         MainMenuId=s.ID,
            //         ApplicationUserId =userAccessRequest.UserId,
            //         Selected = false
            //     }).ToList()
            // }).ToList();



            var userWithManus = await _context.MainMenus
                .Include(us => us.UserSubMenus.Where(us1 => us1.ApplicationUserId == userAccessRequest.UserId)).ToListAsync();
            var result = userWithManus.Select(s => new
            {
                id = s.ID,
                MENUNAME = s.MENUNAME,
                subMenus = s.UserSubMenus.Where(d => d.ApplicationUserId == userAccessRequest.UserId).Select(n => new
                {
                    id = n.SubMenuId,
                    submenuname = n.SUBMENUNAME

                })
            }).ToList();

            foreach (var allMenu in menuWithSubMenus.ToList())
            {
                foreach (var userMenus in result.ToList())
                {
                    if (userMenus.id == allMenu.mainMenuId)
                    {
                        foreach (var userSub in userMenus.subMenus.ToList())
                        {
                            foreach (var allSub in allMenu.subMenu.ToList())
                            {
                                if (userSub.id == allSub.SubMenuId)
                                {
                                    allSub.Selected = true;
                                }
                                //    else
                                //    {
                                //        allSub.Selected=false;
                                //    }

                            }
                        }
                    }


                }

            }
            var subList = new List<UserSubMenu>();
            foreach (var i in menuWithSubMenus.ToList())
            {

                foreach (var s in i.subMenu.ToList())
                {
                    var sub = new UserSubMenu();
                    sub.SUBMENUNAME = s.SUBMENUNAME;
                    sub.SubMenuId = s.SubMenuId;
                    subList.Add(sub);
                }
            }

            return Ok(new { menuWithSubMenus });
        }

        /// <summary>
        /// Get all users
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null)
                return BadRequest(new { Status = "error", Message = "no user found" });
            var result = users.Select(u => new
            {
                UserId = u.Id,
                UserName = u.UserName,
                EmailService = u.Email
            }).ToList();
            return Ok(result);
        }

        /// <summary>
        /// Assign access
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("assign-access")]
        public async Task<IActionResult> AssignAccess([FromBody] List<MainMenus> allMenuSubmapped, string userId)
        {
            //   var userId = "df220c94-56e6-49f5-89dd-ea83d77e56e6";
            var selectedUserExist = await _context.UserSubMenus.FirstOrDefaultAsync(u => u.ApplicationUserId == userId);
            var subMenus = new List<UserSubMenu>();
            foreach (var i in allMenuSubmapped.ToList())
            {

                foreach (var s in i.subMenu.ToList())
                {
                    if (s.Selected == true)
                    {
                        var sub = new UserSubMenu();
                        sub.SUBMENUNAME = s.SUBMENUNAME;
                        sub.SubMenuId = s.SubMenuId;
                        sub.MainMenuId = s.MainMenuId;
                        sub.ApplicationUserId = userId;
                        subMenus.Add(sub);
                    }
                }
            }
            var userSubMenus = new List<UserSubMenu>();
            if (selectedUserExist == null)
            {
                foreach (var s in subMenus.ToList())
                {

                    var sub = new UserSubMenu();
                    sub.ApplicationUserId = userId;
                    sub.MainMenuId = s.MainMenuId;
                    sub.SubMenuId = s.SubMenuId;
                    sub.SUBMENUNAME = s.SUBMENUNAME;
                    sub.ApplicationUserId = userId;
                    sub.MainMenuId = s.MainMenuId;
                    userSubMenus.Add(sub);


                }
                await _context.AddRangeAsync(userSubMenus);
                var isInserted = await _context.SaveChangesAsync() > 0;
                if (!isInserted)

                    return BadRequest(new { status = "error", Message = "already exists" });
                return Ok(new { Status = "success", Message = "user permission assigned", isInserted });

            }

            else
            {
                var applicationUser = await _context.UserSubMenus.Where(u => u.ApplicationUserId == userId).ToListAsync();
                if (applicationUser.Any())
                {
                    _context.UserSubMenus.RemoveRange(applicationUser);

                }
                foreach (var s in subMenus.ToList())
                {

                    var sub = new UserSubMenu();
                    sub.ApplicationUserId = userId;
                    sub.MainMenuId = s.MainMenuId;
                    sub.SubMenuId = s.SubMenuId;
                    sub.SUBMENUNAME = s.SUBMENUNAME;
                    sub.ApplicationUserId = userId;
                    sub.MainMenuId = s.MainMenuId;
                    userSubMenus.Add(sub);


                }
                await _context.AddRangeAsync(userSubMenus);
                var isInserted = await _context.SaveChangesAsync() > 0;
                if (!isInserted)
                    return BadRequest(new { status = "error", Message = "already exists" });
                return Ok(new { Status = "success", Message = "user permission assigned", isInserted });


            }



            //  return Ok(new{Message ="please try again"});
        }

        /// <summary>
        /// Decoder login
        /// </summary>
        [HttpPost("decoder-login")]
        public async Task<IActionResult> DecoderLogin([FromBody] DecoderLoginRequest request)
        {
            DecoderUser findUser = await _context.DecoderUsers.Where(u => u.EMAIL == request.UserEmail).FirstOrDefaultAsync();
            if (findUser == null)
            {
                return BadRequest(new { Status = "error", Message = "invalid email or user" });
            }
            else if (findUser.EMAILVERIFIED != true)
            {
                return BadRequest(new { Status = "error", Message = "user email is not verified" });
            }
            else if (request.Token == "" || findUser.TOKENVALUE == null)
            {
                return await FirsDecoder(request);
            }
            else if (request.Token != null && findUser.EMAILVERIFIED == true)
            {
                return await FinalDecoder(request);
            }
            return Ok(new { status = "error", Message = "error log in" });
        }
        private async Task<IActionResult> FinalDecoder(DecoderLoginRequest request)
        {
            var findUser = await _context.DecoderUsers.FirstOrDefaultAsync(u => u.EMAIL == request.UserEmail);
            if (findUser == null)
                return BadRequest(new { Status = "error", Message = "email not found or user with this email not available" });
            if (findUser.EMAILVERIFIED == false)
                return BadRequest(new { Status = "error", Message = "invalid email" });

            using var hmac = new HMACSHA512(findUser.PASSWORDSALT);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != findUser.PASSWORDHASH[i])
                    return BadRequest(new { status = "error", Message = "password mismatched" });

            }
            var tokenCheck = await _context.DecoderUsers.FirstOrDefaultAsync(t => t.TOKENVALUE == request.Token);
            if (tokenCheck == null)
                return BadRequest(new { Status = "error", Message = "session mismatched" });
            if (tokenCheck.EMAIL == request.UserEmail)
                return BadRequest(new { Status = "error", Message = "first decoder and second decoder can not be the same" });
            if (tokenCheck.TOKENVALUE != request.Token)
                return BadRequest(new { Status = "error", Message = "token mmismatched" });
            if (tokenCheck.TOKENVALUE != request.Token)
                return BadRequest(new { Status = "error", Message = "token mmismatched" });

            return Ok(new
            {
                Message = "final decoder verified",
                userName = findUser.EMAIL
            });
        }
        private async Task<IActionResult> FirsDecoder(DecoderLoginRequest request)
        {
            var findUser = await _context.DecoderUsers.FirstOrDefaultAsync(u => u.EMAIL == request.UserEmail && u.EMAILVERIFIED == true);
            if (findUser == null)
                return BadRequest(new { Status = "error", Message = "invalid user or email" });
            using var hmac = new HMACSHA512(findUser.PASSWORDSALT);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != findUser.PASSWORDHASH[i])
                    return BadRequest(new { status = "error", Message = "password mismatched" });

            }
            var decoderLoginToken = _toeknServe.CreateTokenDecoder(findUser);
            findUser.TOKENVALUE = decoderLoginToken;
            if (findUser.TOKENVALUE == null)
            {
                _context.DecoderUsers.Update(findUser);
                _context.SaveChanges();
            }
            if (findUser.TOKENVALUE != null)
            {
                _context.DecoderUsers.Update(findUser);
                _context.SaveChanges();
            }
            return Ok(new
            {
                Session = decoderLoginToken,
                Message = "first decoder verified",
                userName = findUser.EMAIL
            });

        }

        /// <summary>
        /// Request for new password (Admin)
        /// </summary>
        [HttpPost("forgot_password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var tokenModel = new ChangePassToken();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest(new { status = "error", Message = "no user with this email id" });
            var normalUserToken = await _toeknServe.CreateTokenAdmin(user);
            model.TokenValue = normalUserToken;

            user.TokenValue = normalUserToken;
            if (user.TokenValue == null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            if (user.TokenValue != null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            _authenticateService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok(new Response { Status = "success", Message = "change password link sent, please check your email for verification instructions" });



        }
        /// <summary>
        /// Change password
        /// </summary>
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var findUser = await _context.Users.FirstOrDefaultAsync(x => x.TokenValue == model.TokenValue);
            if (findUser == null)
                return BadRequest(new { status = "error", Message = "wrong link" });

            // var user  = await _userManager.FindByIdAsync(userId);
            var token = await _userManager.GeneratePasswordResetTokenAsync(findUser);
            var result = await _userManager.ResetPasswordAsync(findUser, token, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return BadRequest(new Response { Status = "failed", Message = error.Description });
                }

            }
            return Ok(new { Status = "success", Message = "password reset done" });
            // var resetPassResult = await _userManager.ResetPasswordAsync(findUser,model.TokenValue, model.Password);
            // if(resetPassResult.Succeeded)
            // {
            //     return Ok(new{status ="success",Message ="password reset done"});
            // }
            //return Ok(new{status ="error",Message ="somethis went wrong"});



        }

        /// <summary>
        /// Login (1st Super Admin)
        /// </summary>
        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromBody] LoginModelForSUperAdmin model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return BadRequest(new { status = "error", Message = "no user found" });
            if (user.EmailConfirmed != true)
                return BadRequest(new { Message = "user email is  not verified" });

            if (user == null)
                return BadRequest(new { status = "error", Message = "invalid user name" });
            var roles = await _userManager.GetRolesAsync(user);
            if (model.TokenValue == null)
            {
                if (roles.Contains(Role.SuperAdmin.ToString()))
                {
                    return await SuperAdminPart1(model);
                    //return Ok(new {Message ="super admin"});
                }
            }

            if (model.TokenValue != null)
            {
                return await SuperAdmiFinalStep(model);
            }


            else
            {

                var userId = new UserIdForUserMenu();
                userId.UserId = user.Id;
                var userWithManus = _context.MainMenus
                .Include(us => us.UserSubMenus.Where(us1 => us1.ApplicationUserId == userId.UserId)).ToList();

                var result = userWithManus.Select(s => new
                {
                    id = s.ID,
                    MENUNAME = s.MENUNAME,
                    subMenus = s.UserSubMenus.Where(d => d.ApplicationUserId == userId.UserId).Select(n => new
                    {
                        id = n.SubMenuId,
                        submenuname = n.SUBMENUNAME

                        //subNameis = n.SubMenu.SUBMENUNAME
                    })
                }).ToList();

                foreach (var item in result.ToList())
                {
                    if (!item.subMenus.Any())
                    {
                        result.Remove(item);
                    }
                }

                // var menus = GetUserMenus(userId);

                if (user == null)
                    return BadRequest(new { status = "error", Message = "invalid user name" });
                var passCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!passCheck)
                    return BadRequest(new { Status = "error", Message = "password do not matched" });

                return Ok(new
                {
                    token = await _toeknServe.CreateTokenAdmin(user),
                    Message = "user logged in",
                    userName = user.UserName,
                    Menus = result,
                    // Menus = userWithManus.Select(s => new
                    // {   
                    //     id =s.ID,
                    //     MENUNAME = s.MENUNAME,
                    //     UserSubMenus = s.UserSubMenus.Where(d => d.ApplicationUserId == userId.UserId).Select(n => new
                    //     {
                    //         submenuid = n.SubMenuId,
                    //         subMenuName = n.SUBMENUNAME

                    //         //subNameis = n.SubMenu.SUBMENUNAME
                    //     })
                    // }).ToList()




                }
                );

            }
            // if user is superadmin 



        }
        // [HttpPost("super-admin-log-in-first-step")]
        // public async Task<IActionResult> SuperAdminLogInStep1([FromBody] LoginModel model)
        // {
        //     var user = await _userManager.FindByNameAsync(model.Username);

        //     if (user == null)
        //         return BadRequest(new { status = "error", Message = "invalid user name" });
        //     var passCheck = await _userManager.CheckPasswordAsync(user, model.Password);
        //     if (!passCheck)
        //         return BadRequest(new { Status = "error", Message = "password do not matched" });
        //     var tokenForSuperAdmin = await _toeknServe.CreateTokenAdmin(user);
        //     setSuperAdminCookie(tokenForSuperAdmin);

        //     return Ok(new
        //     {
        //         session = tokenForSuperAdmin,
        //         Message = "first user verified",
        //         userName = user.UserName

        //     }
        //    );

        // }


        private async Task<IActionResult> SuperAdminPart1(LoginModelForSUperAdmin model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            //  var d = _context.Users.Where(u =>u.Id =="40229b9f-1a8f-42e7-acbe-04c756c2a60a").Include(t =>t.SubMenus.Select( s =>s.SUBMENUNAME));

            if (user == null)
                return BadRequest(new { status = "error", Message = "invalid user name" });
            var passCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passCheck)
                return BadRequest(new { Status = "error", Message = "password do not matched" });
            var tokenForSuperAdmin = await _toeknServe.CreateTokenAdmin(user);
            // setSuperAdminCookie(tokenForSuperAdmin);
            user.TokenValue = tokenForSuperAdmin;
            //var userToken = user.TokenValue;
            if (user.TokenValue != null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            if (user.TokenValue == null)
            {
                user.TokenValue = tokenForSuperAdmin;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }



            return Ok(new
            {
                session = tokenForSuperAdmin,
                Message = "first user verified",
                userName = user.UserName

            }
           );

        }

        /// <summary>
        /// Login (2nd Super Admin)
        /// </summary>
        [HttpPost("super-admin-log-in")]
        public async Task<IActionResult> SuperAdminLogInStep2([FromBody] LoginModelForSUperAdmin model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                return BadRequest(new { status = "error", Message = "invalid user name" });
            var passCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passCheck)
                return BadRequest(new { Status = "error", Message = "password do not matched" });


            var userName = model.Username;
            if (model.Username == "superadminpart2@gmail.com")
            {
                userName = "superadminpart1@gmail.com";
            }
            if (model.Username == "superadminpart1@gmail.com")
            {
                userName = "superadminpart2@gmail.com";
            }
            var userWithtoken = await _userManager.FindByNameAsync(userName);

            if (userWithtoken.TokenValue != model.TokenValue)
                return BadRequest(new { Message = "session mismatched" });

            // var superAdminName = "superadmin@gmail.com";
            var firtsLoginToken = model.TokenValue;
            // string firstAdminData = Request.Cookies["superAdminSession"];
            if (firtsLoginToken == null || firtsLoginToken is null)
                return BadRequest(new { Message = "session ended,please try again" });

            // var user = await _userManager.FindByNameAsync(model.Username);

            // if (user == null)
            //     return BadRequest(new { status = "error", Message = "invalid user name" });
            // var passCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            // if (!passCheck)
            //     return BadRequest(new { Status = "error", Message = "password do not matched" });

            var superAdmin = await _userManager.FindByNameAsync(userWithtoken.UserName);
            var roles = await _userManager.GetRolesAsync(superAdmin);
            if (roles.Contains(Role.SuperAdmin.ToString()))
            {
                var allRoles = await _roleManager.Roles.ToListAsync();
                var menus = await AllMenusForAdmin();
            }



            // foreach(var r in allRoles)
            // {
            //     if(r.Name == superAdmin.UserName)
            //     {
            //          GlobalRoleId=r.Id;
            //     }

            // }
            // var RoleIdSearch  = _context.UserRoles.Where(s =>s.UserId==superAdmin.Id).Select(x =>x.RoleId).Single();


            // var permissionModel= await PermissionsForUser(RoleIdSearch);



            return Ok(new SuperAdminResponse
            {
                Token = await _toeknServe.CreateTokenAdmin(superAdmin),
                Message = "User Verified ",
                UserName = superAdmin.UserName,
                UserId = superAdmin.Id,
                Menus = await _context.MainMenus.Include(s => s.SubMenus).ToListAsync()

            }
           );

        }


        private async Task<IActionResult> SuperAdmiFinalStep([FromBody] LoginModelForSUperAdmin model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                return BadRequest(new { status = "error", Message = "invalid user name" });
            var passCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passCheck)
                return BadRequest(new { Status = "error", Message = "password do not matched" });

            var userWithToken = _context.Users.FirstOrDefault(x => x.TokenValue == model.TokenValue);
            if (userWithToken == null)
            {
                return BadRequest(new { Message = "Session mismatched" });
            }
            if (userWithToken.UserName == model.Username)
            {
                return BadRequest(new { Message = "same user can not log in as super admin" });
            }
            if (userWithToken.TokenValue != model.TokenValue)
            {
                return BadRequest(new { Message = "Session mismatched" });
            }

            if (userWithToken == null) return BadRequest(new { Message = "Session mismatched" });

            if (userWithToken.TokenValue != model.TokenValue)
                return BadRequest(new { Message = "session mismatched" });

            // var superAdminName = "superadmin@gmail.com";
            var firtsLoginToken = model.TokenValue;
            // string firstAdminData = Request.Cookies["superAdminSession"];
            if (firtsLoginToken == null || firtsLoginToken is null)
                return BadRequest(new { Message = "session ended,please try again" });


            var superAdmin = await _userManager.FindByNameAsync(model.Username);
            var roles = await _userManager.GetRolesAsync(superAdmin);
            if (!roles.Contains(Role.SuperAdmin.ToString()))
            {
                return BadRequest(new { Message = "Your are not superAdmin" });
            }
            if (roles.Contains(Role.SuperAdmin.ToString()))
            {
                var allRoles = await _roleManager.Roles.ToListAsync();
                var menus = await AllMenusForAdmin();
            }

            return Ok(new SuperAdminResponse
            {
                Token = await _toeknServe.CreateTokenAdmin(superAdmin),
                Message = "User Verified ",
                UserName = superAdmin.UserName,
                UserId = superAdmin.Id,
                Menus = await _context.MainMenus.Include(s => s.SubMenus).ToListAsync()

            }
           );

        }


        /// <summary>
        /// Get all role
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("roles")]
        public async Task<IActionResult> AllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return Ok(roles);
        }

        /// <summary>
        /// Create role (Super Admin)
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("addRole")]
        public async Task<IActionResult> AddRole([FromBody] AddRoelRequestDto addRoelRequestDto)
        {
            if (addRoelRequestDto.RoleName == null)
                return BadRequest(new { Message = "Please add a role name" });
            if (await _roleManager.RoleExistsAsync(addRoelRequestDto.RoleName))
                return BadRequest(new { Message = "role name already exist " });
            var role = await _roleManager.CreateAsync(new IdentityRole(addRoelRequestDto.RoleName.Trim()));
            if (!role.Succeeded)
                return BadRequest(new { Message = "error saving role " });
            return Ok(role);
        }


        private ActionResult GetUserMenus(UserIdForUserMenu model)
        {
            var allMenus = _context.MainMenus.ToList();
            var permittedMenusForUser = _context.UserSubMenus.Where(s => s.ApplicationUserId == model.UserId).ToList();
            var userWithManus = _context.MainMenus
            .Include(us => us.UserSubMenus.Where(us1 => us1.ApplicationUserId == model.UserId)).ToList();
            var result = userWithManus.Select(s => new
            {

                MENUNAME = s.MENUNAME,
                UserSubMenus = s.UserSubMenus.Where(d => d.ApplicationUserId == model.UserId).Select(n => new
                {
                    submenuid = n.SubMenuId,
                    menuName = n.SUBMENUNAME
                    //subNameis = n.SubMenu.SUBMENUNAME


                })
            }).ToList();

            return Ok(result);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("userWithMenu")]

        public IActionResult UserWitSubMenu([FromBody] UserIdForUserMenu model)
        {
            var allMenus = _context.MainMenus.ToList();
            var permittedMenusForUser = _context.UserSubMenus.Where(s => s.ApplicationUserId == model.UserId).ToList();
            var userWithManus = _context.MainMenus
            .Include(us => us.UserSubMenus.Where(us1 => us1.ApplicationUserId == model.UserId)).ToList();
            var result = userWithManus.Select(s => new
            {
                MENUNAME = s.MENUNAME,
                UserSubMenus = s.UserSubMenus.Where(d => d.ApplicationUserId == model.UserId).Select(n => new
                {
                    submenuid = n.SubMenuId,
                    menuName = n.SUBMENUNAME
                    //subNameis = n.SubMenu.SUBMENUNAME


                })
            }).ToList();
            foreach (var item in result.ToList())
            {
                if (!item.UserSubMenus.Any())
                {
                    result.Remove(item);
                }
            }
            return Ok(result);

        }

        /// <summary>
        /// User with roles
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("user-with-roles")]
        public async Task<IActionResult> UserWithRoles(UserWithRoleRequestDto userWithRoleRequestDto)
        {
            if (userWithRoleRequestDto.UserId == null || userWithRoleRequestDto.UserId is null)
                return BadRequest(new { Message = "please provide userid" });
            var userRoleList = new List<UserRolesDto>();
            var user = await _userManager.FindByIdAsync(userWithRoleRequestDto.UserId);
            if (user == null)
                return BadRequest(new { Message = "no user with this id" });
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRoles = new UserRolesDto
                {
                    RoleName = role.Name

                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoles.Selected = true;
                }
                else
                {
                    userRoles.Selected = false;
                }
                userRoleList.Add(userRoles);
            }
            var userWithAssignedRoles = new ManageUserRolesDto()
            {
                UserId = userWithRoleRequestDto.UserId,
                UserRoles = userRoleList
            };

            return Ok(userWithAssignedRoles);
        }

        /// <summary>
        /// User access
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("user-access")]
        public async Task<ActionResult> Permissions(UserWithRoleIdRequestDto roleId)
        {
            var model = new UserAccessModel();
            var allPermissions = new List<RoleClaimsModel>();
            allPermissions.GetPermissions(typeof(Permissions.Products), roleId.roleId);

            var role = await _roleManager.FindByIdAsync(roleId.roleId);
            model.RoleId = roleId.roleId;
            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimValues = allPermissions.Select(a => a.Value).ToList();
            var roleClaimValues = claims.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
            foreach (var permission in allPermissions)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            model.RoleClaims = allPermissions;
            return Ok(model);
        }

        /// <summary>
        /// Get all menus for dashboard
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("all-menus")]
        public async Task<ActionResult> AllMenus()
        {
            var menus = await _context.MainMenus.Include(s => s.SubMenus).ToListAsync();
            return Ok(menus);
        }
        private async Task<ActionResult> AllMenusForAdmin()
        {
            var menus = await _context.MainMenus.Include(s => s.SubMenus).ToListAsync();
            return Ok(menus);
        }

        private async Task<ActionResult> PermissionsForUser(string roleId)
        {
            var model = new UserAccessModel();
            var allPermissions = new List<RoleClaimsModel>();
            allPermissions.GetPermissions(typeof(Permissions.Products), roleId);

            var role = await _roleManager.FindByIdAsync(roleId);
            model.RoleId = roleId;
            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimValues = allPermissions.Select(a => a.Value).ToList();
            var roleClaimValues = claims.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
            foreach (var permission in allPermissions)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            model.RoleClaims = allPermissions;
            return Ok(model);
        }





        private void setSuperAdminCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(3)
            };
            Response.Cookies.Append("superAdminSession", token, cookieOptions);
        }










    }
}