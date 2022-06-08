using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ICABAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public string TokenValue { get; set; }
        public virtual ICollection<UserSubMenu> UserSubMenus { get; set; }
       // public SuperAdminToken SuperAdminToken { get; set; }
    }
}