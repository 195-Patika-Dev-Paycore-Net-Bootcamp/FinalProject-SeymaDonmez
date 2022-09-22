using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Service.Abstract;
using Microsoft.Extensions.Configuration;
using System.Net;
using System;

namespace PaycoreFinalProject.Service.Concrete
{
    public class MailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IRabbitMQService _rabbitMQService;
        public MailService(IOptions<MailSettings> mailSettings, IRabbitMQService rabbitMQService)
        {
            _mailSettings = mailSettings.Value;
            _rabbitMQService = rabbitMQService;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
 
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

            try
            {
                _rabbitMQService.Publish(mailRequest);
            }
            catch (Exception e)
            {

                throw new Exception(message: e.Message);
            }
        }

    }
}
