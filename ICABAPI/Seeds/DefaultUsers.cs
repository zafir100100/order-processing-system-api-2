using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ICABAPI.Constants;
using ICABAPI.Models;
using ICABAPI.Roles;
using Microsoft.AspNetCore.Identity;

namespace ICABAPI.Seeds
{
    public static class DefaultUsers
    {
       public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            var defaultUser = new ApplicationUser
            {
                UserName = "basicuser@gmail.com",
                Email = "basicuser@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Role.BasicUser.ToString());
                }
            }
        }
        public static async Task SeedSuperAdminPre1(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            var defaultUser = new ApplicationUser
            {
                UserName = "superadminpart1@gmail.com",
                Email = "superadminpart1@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "s123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Role.SuperAdmin.ToString());
                }
            }
        }
         public static async Task SeedSuperAdminPre2(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            var defaultUser = new ApplicationUser
            {
                UserName = "superadminpart2@gmail.com",
                Email = "superadminpart2@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "S123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Role.SuperAdmin.ToString());
                }
            }
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null )
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                   // await userManager.AddToRoleAsync(defaultUser, Role.BasicUser.ToString());
                   // await userManager.AddToRoleAsync(defaultUser, Role.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Role.SuperAdmin.ToString());
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }
          
        }

        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "Products");
            //await roleManager.AddPermissionClaim(adminRole, "ProductsType");
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}