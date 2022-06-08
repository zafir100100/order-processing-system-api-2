using System.ComponentModel.DataAnnotations;

namespace ICABAPI.DTOs
{
    public class ResetPasswordRequest
    {
        [Required]
        public int otp{get;set;}
        [Required]
        public string Password{get;set;}
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword{get;set;}
        public int RegistrationNo { get; set; }
    }
}