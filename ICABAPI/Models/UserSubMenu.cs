using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICABAPI.Models
{
    [ Table("USERSUBMENU")]
    public class UserSubMenu
    {
        
        // public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int SubMenuId { get; set; }
        public string SUBMENUNAME { get; set; }
        public SubMenu SubMenu { get; set; }
        public int MainMenuId { get; set; }
        public MainMenu MainMenu { get; set; }



    }
}