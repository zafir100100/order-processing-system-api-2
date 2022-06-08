using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ICABAPI.DTOs.AuthModels
{
    public class RegisterModel
    {
        public string FullName { get; set; } 
        [Required(ErrorMessage = "User Name is required")]  
         [EmailAddress]  
        public string Username { get; set; }  
  
        // [EmailAddress]  
        // [Required(ErrorMessage = "Email is required")]  
        // public string Email { get; set; }  
        [JsonIgnore]
        public string TokenValue { get; set; }             
         [JsonIgnore]
       // [Required(ErrorMessage = "Password is required")]  
         public string Password { get; set; }  
         public string PhoneNumber { get; set; }

        // [DataType(DataType.Password)]
        // [Compare("Password")]
        //  public string ConfirmPassword{get;set;}
    }
    public class RegisterModelForEmailVerify
    {    [Required] 
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
       [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        public string Password { get; set; }  
        [Required] 
        [DataType(DataType.Password)]
        [Compare("Password")]
         
        public string ConfirmPassword{get;set;}
        [Required] 
         public string TokenValue { get; set; }             
  
    }
}