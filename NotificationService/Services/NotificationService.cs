using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NotificationService.Helper;
using NotificationService.Models;

namespace NotificationService.Services
{
    public class NotificationService : INotificationService
    {
        private readonly EmailSettings _emailSettings;
        private readonly IEmailGenerator _emailGenerator;

        public NotificationService(IOptions<EmailSettings> emailSettings, IEmailGenerator emailGenerator)
        {
            _emailSettings = emailSettings.Value;
            _emailGenerator = emailGenerator;
        }

        public async Task sendRegisterMessage(string mail)
        {
            await SendEmail(mail, _emailGenerator.CreateRegisterEmail());
        }
        
        private async Task SendEmail(string to, Email email)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_emailSettings.Email),
            };
            
            mail.To.Add(new MailAddress(to));
            mail.Subject = email.Title;
            mail.Body = email.Content;
            mail.IsBodyHtml = true;

            using var smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password), 
                EnableSsl = _emailSettings.Ssl
            };
            
            await smtp.SendMailAsync(mail);
        }
    }
}