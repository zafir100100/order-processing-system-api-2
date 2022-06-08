using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ICABAPI.Data;
using ICABAPI.DTOs;
using ICABAPI.Entities;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace ICABAPI.Controllers
{
    public class OtPNumber
    {
        public string phoneNumber { get; set; }
    }

    public class AccountController : BaseApiController
    {
        public string CookieValue { get; set; }
        private readonly ModelContext _context;
        private readonly ITokenService _tokenService;
        private const string BaseUrl = "http://sms.bulksmsroute.com/smsapi";
        //private readonly HttpClient _client;
        private readonly IAccountService _accountService;
        public AccountController(ModelContext context, ITokenService tokenService, IAccountService accountService)
        {
            _accountService = accountService;

            _tokenService = tokenService;
            _context = context;


        }

        public class InputForOtp
        {
            public string Ph { get; set; }
        }

        public class OutputForSmsInfo
        {
            public string MSISDN { get; set; }
            public string MSISDNSTATUS { get; set; }
            public string SMSTEXT { get; set; }
            public string CSMSID { get; set; }
            public string REFERENCEID { get; set; }
        }

        /// <summary>
        /// Get Otp
        /// </summary>
        [HttpPost("GetOtp")]
        public OutputForSmsInfo GetOtp([FromBody] InputForOtp input)
        {
            int value;
            Random random = new();
            value = random.Next(100001, 999999);
            //  value = 123456;
            string resp;
            string sid = "ICABOTP";
            string user = "icab";
            string pass = "Icab@123";
            string sms_url = "http://sms.sslwireless.com/pushapi/dynamic/server.php?";
            string myParameters = "user=" + user + "&pass=" + pass + "&msisdn=" + input.Ph + "&sms=" + "Your OTP For Sign Up authentication code:-" + System.Web.HttpUtility.UrlEncode(value.ToString() + " From EXAM") + "&csmsid=" + "1234567890" + "&sid=" + sid;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sms_url + myParameters);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new(stream))
            {
                resp = reader.ReadToEnd();
            }
            HttpContext.Session.SetString("SignOtp", JsonConvert.SerializeObject(value));
            //return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            //{
            //    Message = "Response",
            //    Success = true,
            //    Payload = new
            //    {
            //        Output6 = request,
            //        Output5 = (HttpWebResponse)request.GetResponse(),
            //        Output4 = HttpContext.Session,
            //        Output3 = value,
            //        Output2 = JsonConvert.SerializeObject(value),
            //        Output = resp
            //    }
            //});

            XDocument xDocument = XDocument.Parse(resp);
            var outputForSmsInfos =
                xDocument.Descendants("REPLY")
                         .Select(x => new OutputForSmsInfo
                         {
                             //Courseid = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "courseid").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                             //Grade = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "grade").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                             //Rawgrade = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "rawgrade").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                             //Rank = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "rank").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                             MSISDN = x.Descendants("SMSINFO").Select(a => a.Element("MSISDN")?.Value).FirstOrDefault(),
                             MSISDNSTATUS = x.Descendants("SMSINFO").Select(a => a.Element("MSISDNSTATUS")?.Value).FirstOrDefault(),
                             SMSTEXT = x.Descendants("SMSINFO").Select(a => a.Element("SMSTEXT")?.Value).FirstOrDefault(),
                             CSMSID = x.Descendants("SMSINFO").Select(a => a.Element("CSMSID")?.Value).FirstOrDefault(),
                             REFERENCEID = x.Descendants("SMSINFO").Select(a => a.Element("REFERENCEID")?.Value).FirstOrDefault()
                         });

            List<OutputForSmsInfo> ot = new();
            foreach (var item in outputForSmsInfos)
            {
                OutputForSmsInfo gR = new OutputForSmsInfo();

                gR.MSISDN = item.MSISDN;
                gR.MSISDNSTATUS = item.MSISDNSTATUS;
                gR.SMSTEXT = item.SMSTEXT;
                gR.CSMSID = item.CSMSID;
                gR.REFERENCEID = item.REFERENCEID;

                ot.Add(gR);
            }

            return ot.FirstOrDefault();
        }

        /// <summary>
        /// Check Existing Student for Sign up
        /// </summary>
        [HttpPost("existing-student-signup")]
        public ActionResult<ExistingStudentInfo> ExistingStudentSignUp([FromBody] StudentinfoRequestDto studentinfo)
        {
            var existingUsersInfo = _context.StuReg1s.Where(r => r.RegNo == studentinfo.RegNo).Select(s => new
            {
                s.RegNo,
                s.Email,
                s.Dob,
                s.Name,
                s.Cell
            }).FirstOrDefault();

            if (existingUsersInfo != null) return Ok(existingUsersInfo);
            return NotFound(new { statusCode = 404, message = "no data found" });


        }

        /// <summary>
        /// Resend OTP
        /// </summary>
        [HttpPost("resend-otp")]
        public ActionResult ResendOtp()
        {
            var userSession = Request.Cookies["userOtp"];
            if (userSession != null)
                return BadRequest(new { Message = "Before 2 minutes you can not resend otp" });
            var registrationNO = HttpContext.Session.GetInt32("regNo");
            if (registrationNO == null || registrationNO is null)
                return BadRequest(new { Message = "please sign up again" });
            // return StatusCode(StatusCodes.Status500InternalServerError, 
            //     new ResponseDto { Status = "Error ", Message = "please sign up again" });   

            Random random = new Random();
            var value = random.Next(100001, 999999);

            //int value = (int)registrationNO;
            // value = (int?)registrationNO;
            var cookieValue = value.ToString();
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("userotp", cookieValue, cookie);
            var accountToResendOtp = _context.APPUSER.SingleOrDefault(x => x.RegistrationNo == registrationNO);
            accountToResendOtp.Otp = value;
            _context.APPUSER.Update(accountToResendOtp);
            _context.SaveChanges();

            //var formatedValue = Convert.ToInt32(value);
            //var otp = new OtpCredentials();
            //otp.msg = "Your One Time Validation Password Is " + formatedValue.ToString() + " " + "Please Use This Password To Validate Your Account";
            //otp.Url = "http://sms.bulksmsroute.com/smsapi";
            //otp.api_key = "R60011495ea98c552213b0.48729782";

            //otp.senderid = "8809612446100";
            //// otps.msg=otp.msg;
            //otp.contacts = accountToResendOtp.MobileNo;
            //otp.type = "text";
            // await _accountService.SendOtpSms(otp); 

            string resp;
            string sid = "ICABOTP";
            string user = "icab";
            string pass = "Icab@123";
            string sms_url = "http://sms.sslwireless.com/pushapi/dynamic/server.php?";
            string myParameters = "user=" + user + "&pass=" + pass + "&msisdn=" + accountToResendOtp.MobileNo + "&sms=" + "Your OTP For Sign Up authentication code:-" + System.Web.HttpUtility.UrlEncode(value.ToString() + " From EXAM") + "&csmsid=" + "1234567890" + "&sid=" + sid;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sms_url + myParameters);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new(stream))
            {
                resp = reader.ReadToEnd();
            }
            HttpContext.Session.SetString("SignOtp", JsonConvert.SerializeObject(value));



            return Ok(new
            {
                message = "An otp has sent to your mobile/phone"
            });




        }

        /// <summary>
        /// Update Date of Birth and Email
        /// </summary>
        [HttpPost("update-dob-email")]
        public ActionResult UpdateDobAndEmai([FromBody] UpdateDobEmailDto updateDobEmailDto)
        {
            // var registrationNO = HttpContext.Session.GetInt32("userRegNoForUpdateDob");
            var registrationNO = updateDobEmailDto.RegistrationNumber;

            var studentToUpdate = _context.StuReg1s.SingleOrDefault(s => s.RegNo == registrationNO);
            if (studentToUpdate == null)
                return BadRequest(new { Message = "No student with this registration number" });
            if (studentToUpdate.UserDobChangeLimit > 0)
            {
                studentToUpdate.Dob = updateDobEmailDto.Dob;
                studentToUpdate.Email = updateDobEmailDto.Email;
                studentToUpdate.UserDobChangeLimit -= 1;
                _context.StuReg1s.Update(studentToUpdate);

                var isUpdated = _context.SaveChanges() > 1;
                return Ok(new { Message = "updated", registrationNO });
            }
            else
            {
                studentToUpdate.Email = updateDobEmailDto.Email;
                _context.StuReg1s.Update(studentToUpdate);

                var isUpdated = _context.SaveChanges() > 1;
                return Ok(new { Message = "you can update your date of birth only once , email updated only ", registrationNO });

            }



        }


        /// <summary>
        /// Match OTP from User
        /// </summary>
        [HttpPost("confirm-otp")]
        public ActionResult OtpConfirmation([FromBody] OtpRequestDto userOtp)
        {
            var userSession = Request.Cookies["userOtpForUpdateDob"];
            if (userSession == null)
                return BadRequest(new { Message = "please  resend otp and try again" });
            // return StatusCode(StatusCodes.Status500InternalServerError, 
            // new ResponseDto { Status = "Error ", Message = "please  resend otp and try again" });   
            var convertedOtp = int.Parse(userSession);
            // var value = random.Next(100001, 999999);
            //var result = "otp matched";
            if (convertedOtp != userOtp.Otp)
                return BadRequest(new { message = "otp miss matched" });
            return Ok(new { message = "otp matched" });

        }

        /// <summary>
        /// Send OTP
        /// </summary>
        [HttpPost("Send-otp")]
        public ActionResult SendOtpAsync([FromBody] SendOtpRequestDto otpRequestDto)
        {

            // Prottoy //

            //Random random = new Random();
            //var value = random.Next(100001, 999999);
            ////int value = otpRequestDto.RegistrationNo;
            //// value = (int?)registrationNO;
            //var formatedValue = Convert.ToInt32(value);
            //var otp = new OtpCredentials();
            //otp.msg = "Your One Time Validation Password Is " + formatedValue.ToString() + " " + "Please Use This Password To Validate Your Account";
            //otp.Url = "http://sms.bulksmsroute.com/smsapi";
            //otp.api_key = "R60011495ea98c552213b0.48729782";
            //otp.senderid = "8809612446100";
            //// otps.msg=otp.msg;
            //otp.contacts = otpRequestDto.PhoneNo;
            //otp.type = "text";


            // ICAB //

            Random random = new();
            var value = random.Next(100001, 999999);

            System.Diagnostics.Debug.WriteLine("SHUVO" + value);
            //  value = 123456;
            string resp;
            string sid = "ICABOTP";
            string user = "icab";
            string pass = "Icab@123";
            string sms_url = "http://sms.sslwireless.com/pushapi/dynamic/server.php?";
            string myParameters = "user=" + user + "&pass=" + pass + "&msisdn=" + otpRequestDto.PhoneNo + "&sms=" + "Your OTP For Sign Up authentication code:-" + System.Web.HttpUtility.UrlEncode(value.ToString() + " From EXAM") + "&csmsid=" + "1234567890" + "&sid=" + sid;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sms_url + myParameters);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new(stream))
            {
                resp = reader.ReadToEnd();
            }
            HttpContext.Session.SetString("SignOtp", JsonConvert.SerializeObject(value));



            if (otpRequestDto.PhoneNo == null || otpRequestDto.PhoneNo == "")
                return BadRequest(new { Message = "No phone number is provided to send otp" });
            var userSessionForOtp = Request.Cookies["userOtpForUpdateDob"];
            if (userSessionForOtp != null)
                return BadRequest(new { Message = "already an otp has sent to your phone", sessionId = userSessionForOtp });

            //await _accountService.SendOtpSms(otp); 

            StoreOptSessionForUpdateDob(value, otpRequestDto);
            this.CookieValue = Request.Cookies["userOtpForUpdateDob"];
            return Ok(new
            {
                message = "An otp has sent to your mobile/phone",
                sessionId = this.CookieValue
            });


        }

        /// <summary>
        /// Get User number to Send OTP
        /// </summary>
        [HttpPost("otp-icab-check")]
        public IActionResult OtpIcab([FromBody] OtPNumber number)
        {
            var phoneNumber = number.ToString();
            var smsMessage = sendSMSLogin(phoneNumber);
            return Ok(smsMessage);
        }
        private string sendSMSLogin(string phn)
        {

            Random random = new Random();

            var value = random.Next(100001, 999999);
            //value = 1234;


            string resp;
            String sid = "IcabOTPBangla";
            String user = "icab";
            String pass = "Icab@123";
            string sms_url = "http://sms.sslwireless.com/pushapi/dynamic/server.php?";
            String myParameters = "user=" + user + "&pass=" + pass + "&msisdn=" + phn + "&sms=" + "Your OTP For Login :-" + System.Web.HttpUtility.UrlEncode(value.ToString() + " From DVS two-factor authentication code.") + "&csmsid=" + "1234567890" + "&sid=" + sid;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sms_url + myParameters);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                resp = reader.ReadToEnd();
            }



            HttpContext.Session.SetString("LoginOtp", JsonConvert.SerializeObject(value));
            // HttpContext.Session.SetString("otp", value);
            return resp;
        }


        /// <summary>
        /// Create New User (Student)
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponseDto>> Register([FromBody] RegisterDto registerDto)
        {

            // ICAB //

            Random random = new();
            var value = random.Next(100001, 999999);

            System.Diagnostics.Debug.WriteLine("SHUVO" + value);
            //  value = 123456;

            // if (await UserExists(registerDto.RegistrationNo)) return BadRequest("User is already exists");
            HttpContext.Session.SetInt32("regNo", registerDto.RegistrationNo);
            if (await UserExists(registerDto.RegistrationNo))
            {
                return Conflict(new { message = "user already exist", statusCode = Conflict().StatusCode });
            }
            AppUser appUser = await _context.APPUSER.Where(i => i.RegistrationNo == registerDto.RegistrationNo).FirstOrDefaultAsync();
            if (appUser != null)
            {
                _context.APPUSER.Remove(appUser);
                await _context.SaveChangesAsync();
            }
            //  return StatusCode(StatusCodes.Status500InternalServerError, 
            //  new ResponseDto { Status = "Error ", Message = "User already exists!" });  


            using var hmac = new HMACSHA512();
            var user = new AppUser()
            {
                UserName = registerDto.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                RegistrationNo = registerDto.RegistrationNo,
                DateOfBirth = registerDto.DateOfBirth,
                Email = registerDto.Email,
                MobileNo = registerDto.MobileNo,
                IsVerified = false,
                Otp = value


            };
            StoreOptSession(value, registerDto);
            // var cookieValue = value.ToString();
            // CookieOptions cookie = new CookieOptions();
            // cookie.Expires=DateTime.Now.AddMinutes(5);
            // Response.Cookies.Append("userotp",cookieValue,cookie);
            // HttpContext.Session.SetInt32("regNo",registerDto.RegistrationNo);


            _context.APPUSER.Add(user);

            var otpSend = await _context.SaveChangesAsync();
            var formatedValue = Convert.ToInt32(value);

            // Prottoy //

            //var otp = new OtpCredentials();
            //otp.msg = "Your One Time Validation Password Is " + formatedValue.ToString() + "" + "Please Use This Password To Validate Your Account";
            //otp.Url = "http://sms.bulksmsroute.com/smsapi";
            //otp.api_key = "R60011495ea98c552213b0.48729782";

            //otp.senderid = "8809612446100";
            //// otps.msg=otp.msg;
            //otp.contacts = user.MobileNo;
            //otp.type = "text";

            // ICAB //

            string resp;
            string sid = "ICABOTP";
            string usericab = "icab";
            string pass = "Icab@123";
            string sms_url = "http://sms.sslwireless.com/pushapi/dynamic/server.php?";
            string myParameters = "user=" + usericab + "&pass=" + pass + "&msisdn=" + registerDto.MobileNo + "&sms=" + "Your OTP For Sign Up authentication code:-" + System.Web.HttpUtility.UrlEncode(value.ToString() + " From EXAM") + "&csmsid=" + "1234567890" + "&sid=" + sid;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sms_url + myParameters);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new(stream))
            {
                resp = reader.ReadToEnd();
            }
            HttpContext.Session.SetString("SignOtp", JsonConvert.SerializeObject(value));


            var last3DigitsOfUserMobile = registerDto.MobileNo.Substring(registerDto.MobileNo.Length - 2);

            // await _accountService.SendOtpSms(otp); 

            //await SendOtpAsync(otp);

            return new RegistrationResponseDto
            {
                UserName = user.UserName,
                Msg = "Verification otp is sent to" + ",********* " + last3DigitsOfUserMobile + " " + "please verify your account"

            };

        }

        /// <summary>
        /// Verify new created student (By OTP) 
        /// </summary>
        [HttpPost("verify-account")]
        public ActionResult VerifyAccount([FromBody] OtpRequestDto otp)
        {

            string userOtp = Request.Cookies["userotp"];
            if (userOtp is null || userOtp == null)
                return BadRequest(new { Message = "otp expired try again" });
            // return StatusCode(StatusCodes.Status500InternalServerError, 
            //     new ResponseDto { Status = "Error ", Message = "otp expired try again" });   
            //var account = _context.APPUSER.SingleOrDefault(x => x.Otp == otp);
            var account = _context.APPUSER.ToList();
            var data = account.Where(x => x.Otp == otp.Otp);
            if (!data.Any())
                return BadRequest(new { Message = "otp does not match" });
            // return StatusCode(StatusCodes.Status500InternalServerError, 
            //     new ResponseDto { Status = "Error ", Message = "otp does not match" });  

            //if (account == null) BadRequest("invalid otp");
            var registrationNO = HttpContext.Session.GetInt32("regNo");
            var accountToVarify = _context.APPUSER.SingleOrDefault(x => x.Otp == otp.Otp);
            var accoutCheck = accountToVarify.RegistrationNo == registrationNO;
            accountToVarify.IsVerified = true;
            if (!accoutCheck)
                return BadRequest(new { Message = "registration number do not match with otp" });
            _context.APPUSER.Update(accountToVarify);
            _context.SaveChanges();
            return Ok(new { message = "Verification successful, you can now login" });
        }



        /// <summary>
        /// Student Login
        /// </summary>
        [HttpPost("login")]
        public ActionResult<UserDto> Login(LogInDto logInDto)
        {
            var user = _context.APPUSER.SingleOrDefault(x => x.RegistrationNo == logInDto.RegistrationNo);
            if (user == null)
            {
                return BadRequest(new { message = "User does not Exist! Please Signup" });

            }

            var veryfiedUser = _context.APPUSER.SingleOrDefault(x => x.RegistrationNo == logInDto.RegistrationNo && x.IsVerified == true);
            if (veryfiedUser == null && user != null)
            {
                return BadRequest(new { message = "OTP is not verified" });

            }

            var response = _accountService.Authinticate(logInDto, ipAddress());
            if (response == null)
                return BadRequest(new { message = "registration number or password is incorrect" });



            setTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        /// <summary>
        /// Refresh token
        /// </summary>
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _accountService.RefreshToken(refreshToken, ipAddress());

            if (response == null)
                return Unauthorized(new { message = "Invalid token" });

            setTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        /// <summary>
        /// Verify Token
        /// </summary>
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken([FromBody] RevokeTokenRequestDto model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            var response = _accountService.RevokeToken(token, ipAddress());

            if (!response)
                return NotFound(new { message = "Token not found" });

            return Ok(new { message = "Token revoked" });
        }

        /// <summary>
        /// Request for new password
        /// </summary>
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
        {
            Random random = new Random();
            var value = random.Next(100001, 999999);
            //var value = model.RegistrationNo;
            model.OtpValue = value;

            var result = await _accountService.ForgotPasswordAsync(model);
            var registrationInfo = new RegisterDto();
            registrationInfo.RegistrationNo = model.RegistrationNo;
            StoreOptSession(value, registrationInfo);
            if (result) return Ok(new { message = "Please check your phone for password reset instructions" });
            return Conflict(new { message = "Invalid registration Number" });
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        [HttpPost("reset-password")]
        public async Task<ActionResult> forgotPasswordUpdate([FromBody] ResetPasswordRequest resetPassword)
        {
            // var account = _context.APPUSER.SingleOrDefault(x => x.RegistrationNo == resetPassword.RegistrationNo);
            // if (account == null)
            // return BadRequest("Invalid token");
            var registrationNO = HttpContext.Session.GetInt32("regNo");
            var userSessionForOtp = Request.Cookies["userOtp"];

            if (registrationNO == null || registrationNO is null)
                return BadRequest(new { Message = "please resend otp and try again" });
            if (userSessionForOtp == null || userSessionForOtp is null)
                return BadRequest(new { Message = "please resend otp and try again" });
            var veryfiedUser = await _context.APPUSER.SingleOrDefaultAsync(x => x.Otp == resetPassword.otp && x.IsVerified == true);
            if (veryfiedUser == null)
            {
                return BadRequest("Account is not validated ");
            }

            using var hmac = new HMACSHA512();
            {



                veryfiedUser.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(resetPassword.Password));
                veryfiedUser.PasswordSalt = hmac.Key;

            }
            // var user = new AppUser()
            // {

            //     PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(resetPassword.Password)),
            //     PasswordSalt = hmac.Key,
            // };
            _context.APPUSER.Update(veryfiedUser);
            await _context.SaveChangesAsync();

            return Ok(new { message = "password reset done" });

        }
        private async Task<bool> UserExists(int registrationNO)
        {
            return await _context.APPUSER.AnyAsync(x => x.RegistrationNo == registrationNO && x.IsVerified == true);
        }
        private void StoreOptSession(int value, RegisterDto registerDto)
        {
            var cookieValue = value.ToString();
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(2);
            Response.Cookies.Append("userotp", cookieValue, cookie);

            HttpContext.Session.SetInt32("regNo", registerDto.RegistrationNo);

        }
        private void StoreOptSessionForUpdateDob(int value, SendOtpRequestDto sendOtpRequestDto)
        {

            var cookieValue = value.ToString();
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(2);
            Response.Cookies.Append("userOtpForUpdateDob", cookieValue, cookie);
            HttpContext.Session.SetInt32("userRegNoForUpdateDob", sendOtpRequestDto.RegistrationNo);

        }


        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }


    }
}