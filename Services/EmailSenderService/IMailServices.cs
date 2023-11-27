using Dtos.EmailDtos.MailRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.EmailSenderService
{
    public class IMailServices
    {
        public interface IMailService
        {
            Task SendEmailForgetPassword(MailRequest mailRequest);
            Task SendEmailAsync(MailRequest mailRequest);

        }
    }
}
