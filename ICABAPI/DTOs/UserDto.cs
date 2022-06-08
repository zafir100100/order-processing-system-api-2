using Newtonsoft.Json;

namespace ICABAPI.DTOs
{
    public class UserDto
    {
        // public string UserName{get;set;}
        public string Toekn{get;set;}
        public string Msg{get;set;}
        [JsonIgnore]
        public string RefreshToken { get; set; }
        public string UserName{get;set;}
        public int RegistrationNumber { get; set; }

        public UserDto(string token ,string message,string refreshToken)
        {
           
            Toekn=token;
            Msg=message;
            RefreshToken=refreshToken;
           

        }
        public UserDto(string token ,string message,string refreshToken,string userName)
        {
           
            Toekn=token;
            Msg=message;
            RefreshToken=refreshToken;
            UserName=userName;
           

        }
        public UserDto(string token ,string message,string refreshToken,string userName,int regNo)
        {
           
            Toekn=token;
            Msg=message;
            RefreshToken=refreshToken;
            UserName=userName;
            RegistrationNumber=regNo;

        }
        public UserDto(string message)
        {
            Msg=message;
        }
        
    }
}