using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Entities;
using ICABAPI.Helpers;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ICABAPI.Data
{
    public class AccountRepository : IAccountService
    {
        private readonly ModelContext _context;
        private readonly ITokenService _tokenService;
        public AccountRepository(ModelContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;

        }

        public UserDto Authinticate(LogInDto logInDto, string ipAddress)
        {
            var user = _context.APPUSER.SingleOrDefault(x => x.RegistrationNo == logInDto.RegistrationNo);
            if (user == null)
            {

                return null;

            }
            var veryfiedUser = _context.APPUSER.SingleOrDefault(x => x.RegistrationNo == logInDto.RegistrationNo && x.IsVerified == true);
            if (veryfiedUser == null)
            {
                return null;

            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logInDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return null;

            }
            var jwtToken = _tokenService.CreateToken(user);
            var refreshToken = generateRefreshToken(ipAddress);
            user.RefreshTokens.Add(refreshToken);
            _context.Update(user);
            _context.SaveChanges();
            return new UserDto(jwtToken, "log is successful", refreshToken.Token, veryfiedUser.UserName, veryfiedUser.RegistrationNo);

        }

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordRequest model)
        {
            var account = _context.APPUSER.SingleOrDefault(x => x.RegistrationNo == model.RegistrationNo);
            if (account == null) return false;
            var ifVeryfiedAccount = _context.APPUSER.SingleOrDefault(x => x.RegistrationNo == model.RegistrationNo && x.IsVerified == true);
            if (ifVeryfiedAccount == null) return false;
            //Random random = new Random();
            var value = model.OtpValue;

            System.Diagnostics.Debug.WriteLine("SHUVO2 " + value);
            // var value = random.Next(100001, 999999);

            // Prottoy
            //var formatedValue = Convert.ToInt32(value);
            //var otp = new OtpCredentials();
            //otp.msg = "Your One Time Validation Password Is " + formatedValue.ToString() + "" + "Please Use This Password To Validate Your Account";
            //otp.Url = "http://sms.bulksmsroute.com/smsapi";
            //otp.api_key = "C20021995e9ef98a1a06f4.75414861";

            //otp.senderid = "20789";
            //// otps.msg=otp.msg;
            //otp.contacts = ifVeryfiedAccount.MobileNo;
            //otp.type = "text";
            //await SendOtpSms(otp);

            // ICAB

            string resp;
            string sid = "ICABOTP";
            string usericab = "icab";
            string pass = "Icab@123";
            string sms_url = "http://sms.sslwireless.com/pushapi/dynamic/server.php?";
            string myParameters = "user=" + usericab + "&pass=" + pass + "&msisdn=" + ifVeryfiedAccount.MobileNo + "&sms=" + "Your OTP For Sign Up authentication code:-" + System.Web.HttpUtility.UrlEncode(value.ToString() + " From EXAM") + "&csmsid=" + "1234567890" + "&sid=" + sid;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sms_url + myParameters);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new(stream))
            {
                resp = await reader.ReadToEndAsync();
            }
            //HttpContext.Session.SetString("SignOtp", JsonConvert.SerializeObject(value));


            account.Otp = value;
            _context.APPUSER.Update(account);
            _context.SaveChanges();
            return true;




        }


        public Task<string> ForgotPasswordUpdate(int otp)
        {
            throw new NotImplementedException();
        }


        public UserDto RefreshToken(string token, string ipAddress)
        {
            var user = _context.APPUSER.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            // return null if no user found with token
            if (user == null) return null;
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            // return null if token is no longer active
            if (!refreshToken.IsActive) return null;
            // replace old refresh token with a new one and save
            var newRefreshToken = generateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            user.RefreshTokens.Add(newRefreshToken);
            _context.Update(user);
            _context.SaveChanges();
            var jwtToken = _tokenService.CreateToken(user);
            return new UserDto(jwtToken, "log is successful", refreshToken.Token);
        }

        public bool RevokeToken(string token, string ipAddress)
        {
            var user = _context.APPUSER.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive) return false;

            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;

            _context.Update(user);
            _context.SaveChanges();
            return true;
        }

        public async Task<string> SendOtpSms(OtpCredentials otp)
        {
            using (var _client = new HttpClient())
            {
                var otps = new OtpCredentials();

                //otps.msg ="Your One Time Validations Password Is "+otp.msg.ToString();
                otps.msg = "Your One Time Validations Password Is " + otp.msg.ToString() + "" + "If you get this msg please call Mr. Roy ";

                otps.Url = otp.Url;
                otps.api_key = otp.api_key;
                otps.senderid = otp.senderid;
                otps.contacts = otp.contacts;
                otps.type = otp.type;

                var content = JsonConvert.SerializeObject(otp);
                var httpResponse = await _client.PostAsync(otp.Url, new StringContent(content, Encoding.Default, "application/json"));

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot send a otp");
                }
                return "Verificaton Otp Sent";
                //return Ok(httpResponse);


            }

        }
        private RefreshToken generateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }


    }
}