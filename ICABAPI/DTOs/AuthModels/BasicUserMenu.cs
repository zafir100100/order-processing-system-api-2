using System.Collections.Generic;

namespace ICABAPI.DTOs.AuthModels
{
    public class BasicUserMenu
    {   
        public BasicUserMenu()
        {
            Submenus = new List<BasicUserSubMenu>();
            MenuNames = new List<MenusNames>();
        }
        public string MenuName { get; set; }
        public List<BasicUserSubMenu> Submenus { get; set; }
        public List<MenusNames> MenuNames { get; set; }
    }

     public  class BasicUserSubMenu 
    {
        public string SubMenuName { get; set; } 
        public string MenuName { get; set; }
    }
     public  class MenusNames
    {
        public string MenuName { get; set; }
    }
}