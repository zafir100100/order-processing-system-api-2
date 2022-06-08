namespace ICABAPI.DTOs.AdminDto
{
    public class UserSubMenuDto
    {
        public string ApplicationUserId { get; set; }
       
        public int SubMenuId { get; set; }
        public SubMenuDto SubMenu { get; set; }
        public int MainMenuId { get; set; }
        public MainMenuDto MainMenu { get; set; }
    }
}