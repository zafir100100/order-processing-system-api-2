using System.Collections.Generic;
using ICABAPI.Models;

namespace ICABAPI.DTOs.AuthModels
{
    public class SuperAdminResponse
    {
        public SuperAdminResponse()
        {
            Menus= new HashSet<MainMenu>();
        }
        public string Token { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public ICollection<MainMenu> Menus { get; set; }
        

    }
}