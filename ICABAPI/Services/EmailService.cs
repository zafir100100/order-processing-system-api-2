using System.Net.Mail;
using MailKit.Net.Smtp;
using ICABAPI.Helpers;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace ICABAPI.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
    }
    public class EmailService : IEmailService
    {
       private readonly AppSettings _appSettings;

        public EmailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public void Send(string to, string subject, string html, string from =null)
        {

            var email = new MimeMessage();
           // email.From.Add(MailboxAddress.Parse("satcomdevs@gmail.com"));
            email.From.Add(MailboxAddress.Parse("exam@icab.org.bd"));  //software@satcombd.com
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
           // smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
           // smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.StartTls);
          //  smtp.Authenticate("satcomdevs@gmail.com","Devs@satcom");
           smtp.Authenticate("exam@icab.org.bd", "ICAB_SATCOM1");//SITsection@2003
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}