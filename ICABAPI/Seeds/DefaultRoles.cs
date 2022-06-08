using System.Threading.Tasks;
using ICABAPI.Models;
using ICABAPI.Roles;
using Microsoft.AspNetCore.Identity;

namespace ICABAPI.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync ( UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Role.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Role.Superadminpart1.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Role.superadminpart2.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Role.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Role.BasicUser.ToString()));

        }
    }
}