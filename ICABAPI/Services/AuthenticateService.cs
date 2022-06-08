using ICABAPI.DTOs.AuthModels;
using ICABAPI.DTOs.Decoder;

namespace ICABAPI.Services
{

    public interface IAuthenticateService
    {
        void Register(RegisterModel model, string origin);
        void  DecoderRegister(SignUpRequest model,string origin);
        void ForgotPassword (ForgotPasswordModel model,string origin);
    }

    public class AuthenticateService : IAuthenticateService
    {
        private readonly IEmailService _emailService;
        public AuthenticateService(IEmailService emailService)
        {
            _emailService = emailService;

        }
        public void Register(RegisterModel model, string origin)
        {
            sendVerificationEmail(model,origin);
        }
        public void DecoderRegister(SignUpRequest model, string origin)
        {
            sendVerificationEmailForDecoder(model,origin);
        }
        
         private void sendVerificationEmailForDecoder(SignUpRequest account, string origin)
        {
            //string message;
            ////origin = "http://202.84.32.86:8018";
            ////  if (!string.IsNullOrEmpty(origin))
            ////  {
            ////      var verifyUrl = $"{origin}/api​/admin​/v1​/Authenticate​/assign-access?link={account.TokenValue}";
            ////     message = $@"<p>Please click the below link to verify your email address:</p>
            ////                  <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            ////     // var verifyUrl = $"{origin}/api/admin/v1/Authenticate/decoder-verify-email?link={account.TokenValue}";
            ////     // message = $@"<p>Please click the below link to verify your email address:</p>
            ////     //              <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            ////  }
            ////  else
            ////  {
            //     message = $@"<p>Please use the below link to verify your email address with the <code>/api/admin/v1/Authenticate/decoder-verify-email</code> api route:</p>
            //                  <p><code>{account.TokenValue}</code></p>";
            //// }

            string message;
            origin = "http://202.84.32.86:8019";
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/decoder-verify-email?link={account.TokenValue}";
                message = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Please use the below link to verify your email address with the <code>/api/admin/v1/Authenticate/decoder-verify-email</code> api route:</p>
                              <p><code>{account.TokenValue}</code></p>";
            }

            _emailService.Send(
                to: account.EMAIL,
                subject: "Sign-up Verification API - Verify Email",
                html: $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {message}"
            );
        }

        private void sendVerificationEmail(RegisterModel account, string origin)
        {
            string message;
            origin = "http://202.84.32.86:8019";
             if (!string.IsNullOrEmpty(origin))
             {
                var verifyUrl = $"{origin}/verify-email?link={account.TokenValue}";
                message = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
             }
             else
             {
                 message = $@"<p>Please use the below link to verify your email address with the <code>/api/admin/v1/Authenticate/verify-email</code> api route:</p>
                              <p><code>{account.TokenValue}</code></p>";
             }

            _emailService.Send(
                to: account.Username,
                subject: "Sign-up Verification API - Verify Email",
                html: $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {message}"
            );
        }

        public void ForgotPassword(ForgotPasswordModel model, string origin ="http://202.84.32.86:8019")
        {
            string message;
            origin ="http://202.84.32.86:8019";
            
                 if (!string.IsNullOrEmpty(origin))
             {
                var verifyUrl = $"{origin}/verify-email?link={model.TokenValue}";
                message = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
             }
             else
             {
                 message = $@"<p>Please use the below link to verify your email address with the <code>/api/admin/v1/Authenticate/verify-email</code> api route:</p>
                              <p><code>{model.TokenValue}</code></p>";
             }
             

            _emailService.Send(
                to: model.Email,
                subject: "Forgot password Verification API - Verify Email",
                html: $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {message}"
            );
        }
    }
}