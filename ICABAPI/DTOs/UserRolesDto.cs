using System.Collections.Generic;

namespace ICABAPI.DTOs
{
    public class UserRolesDto
    {
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
    public class ManageUserRolesDto
    {
        public string UserId { get; set; }
        public IList<UserRolesDto> UserRoles { get; set; }
    }
}