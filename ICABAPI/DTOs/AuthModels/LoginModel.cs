using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICABAPI.DTOs.AuthModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]  
        public string Username { get; set; }  
  
        [Required(ErrorMessage = "Password is required")]  
        public string Password { get; set; }  
    }
    public class LoginModelForSUperAdmin
    {
        [Required(ErrorMessage = "User Name is required")]  
        public string Username { get; set; }  
  
        [Required(ErrorMessage = "Password is required")]  
        public string Password { get; set; }  
       
        public string TokenValue { get; set; }
    }
    public class UserIdForUserMenu 
    {
        public string UserId { get; set; }
    }
    public class ForgotPasswordModel
    {
        public string Email { get; set; }
        public string TokenValue { get; set; }
      
    }
    public class ChangePassToken
    {
        public string TokenValue { get; set; }
    }
    public class ChangePasswordModel
    {
        [Required]
        public string TokenValue { get; set; }
         [Required]
        public string  Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string  ConfirmPassword { get; set; }
    }

}