using System.Text.Json.Serialization;
using ICABAPI.DTOs.AdminDto;

namespace ICABAPI.DTOs.AuthModels
{
    public class SubMenusDto
    {
        
        public string SUBMENUNAME { get; set; }
         [JsonIgnore]
        public string SUBMENUURL { get; set; }
         [JsonIgnore]
        public int? MAINMENUID { get; set; }
        public virtual MainMenuDto MainMenu{get;set;}
    }
}