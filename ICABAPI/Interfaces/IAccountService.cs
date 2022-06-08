using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Entities;

namespace ICABAPI.Interfaces
{
    public interface IAccountService
    {
        Task<bool> ForgotPasswordAsync(ForgotPasswordRequest model);
        Task<string> SendOtpSms(OtpCredentials otp );
        Task<string> ForgotPasswordUpdate(int otp);
        UserDto Authinticate(LogInDto logInDto,string ipAddress);
        UserDto RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);
    }
}