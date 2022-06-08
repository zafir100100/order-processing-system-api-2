using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ICABAPI.Models
{
    [Table("MAINMENU")]
    public partial class MainMenu
    {
        public MainMenu()
        {
            SubMenus = new HashSet<SubMenu>();
        }
        [Key]
        
        public int ID { get; set; }
        public string MENUNAME { get; set; }
        [JsonIgnore]

        public string MENUURL { get; set; }
         [JsonIgnore]
        public virtual ICollection<SubMenu> SubMenus { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserSubMenu> UserSubMenus { get; set; }
        


    }
}