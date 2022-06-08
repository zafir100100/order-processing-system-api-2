using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ICABAPI.DTOs.Decoder
{
    public class SignUpRequest
    {
        public string NAME { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }
        // public string PASSWORD { get; set; }
        // [DataType(DataType.Password)]
        // [Compare("PASSWORD")]
        // public string CONFIRMPASSWORD{get;set;}

       // [JsonIgnore]
        public string TokenValue{get;set;}
       
        
    }
    public class DecoderVerifyEmailRequest
    {   
        [Required]
        public string Token { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    public class SignUpToken
    {
        public string TokenValue { get; set; }
    }
    public class DecoderLoginRequest
    {
        public string UserEmail { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    
}