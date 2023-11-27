using System; 
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MimeKit;
using System.IO; 
using MailKit.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net.Mail;
using static Services.EmailSenderService.IMailServices;
using TicketingSystemNKU.Dtos.EmailDtos.MailRequests;
using Dtos.EmailDtos.MailRequests;

namespace Services.EmailSenderService
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                ServicePointManager.ServerCertificateValidationCallback =
               delegate (
                   object s,
                   X509Certificate certificate,
                   X509Chain chain,
                   SslPolicyErrors sslPolicyErrors
               ) {
                   return true;
               };
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch(Exception) { throw; }
        }

        public async Task SendEmailForgetPassword(MailRequest mailRequest)
        {
            try
            {
                using (var client = new System.Net.Mail.SmtpClient())
                {
                    client.UseDefaultCredentials = false;

                    var credential = new NetworkCredential
                    {
                        UserName = _mailSettings.Mail,
                        Password = _mailSettings.Password,

                    };
                    client.Credentials = credential;
                    client.Host = _mailSettings.Host;
                    client.Port = _mailSettings.Port;
                    client.EnableSsl = true;

                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress(mailRequest.ToEmail));
                        emailMessage.From = new MailAddress(_mailSettings.Mail);
                        emailMessage.Subject = mailRequest.Subject;
                        emailMessage.IsBodyHtml = true;
                        emailMessage.Body = mailRequest.Body;

                        try
                        {
                            ServicePointManager.ServerCertificateValidationCallback =
                   delegate (
                       object s,
                       X509Certificate certificate,
                       X509Chain chain,
                       SslPolicyErrors sslPolicyErrors
                   )
                   {
                       return true;
                   };
                            client.Send(emailMessage);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }
                }
                await Task.CompletedTask;
            }
            catch (Exception) { throw; }
        }
    }
}
