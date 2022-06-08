using System.Collections.Generic;
using ICABAPI.Models;

namespace ICABAPI.DTOs.AdminDto
{
    public class MainMenuDto
    {
       public MainMenuDto()
       {
           UserSubMenus = new HashSet<UserSubMenu>();
       }
        public string MENUNAME { get; set; }
        //  public virtual ICollection<UserSubMenuDto> UserSubMenus { get; set; }
        
       // public List <string> UserSubMenus { get; set; }
         
        public virtual ICollection<UserSubMenu> UserSubMenus { get; set; }
    }
}