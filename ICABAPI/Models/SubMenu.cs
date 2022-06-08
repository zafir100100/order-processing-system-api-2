using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ICABAPI.Models
{
    [Table("SUBMENU")]
    public partial class SubMenu
    {
        public SubMenu()
        {
            UserSubMenus = new HashSet<UserSubMenu>(); 
        }
        [Key]
       
        public int ID { get; set; }
        public string SUBMENUNAME { get; set; } 
        [JsonIgnore]
        public string SUBMENUURL { get; set; }
        [JsonIgnore]
        public int? MAINMENUID { get; set; }
        public virtual MainMenu MainMenu{get;set;}
       
        [JsonIgnore]
        public virtual ICollection<UserSubMenu> UserSubMenus { get; set; }
        //public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}