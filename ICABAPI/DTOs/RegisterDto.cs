using System;
using System.ComponentModel.DataAnnotations;

namespace ICABAPI.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName{get;set;}
        [Required]
       [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
       [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]

        public string Password{get;set;}
         [Required]
         [Range(1,10000000,ErrorMessage ="must be between 1 and 10000000")]
        public int RegistrationNo{get;set;}
         [Required]
        public DateTime DateOfBirth{get;set;}
         [Required]
        public string Email {get;set;}
         [Required]
        public string MobileNo{get;set;}
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword{get;set;}
    }
}