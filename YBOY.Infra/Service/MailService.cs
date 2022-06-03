using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YBOY.Core.DTO;

using MailKit.Net.Smtp;
using MailKit.Security;
using YBOY.Core.Service;

namespace YBOY.Infra.Service
{
    public class MailService : IMailService
    {
        private readonly MailSettings mailSettings;

        public MailService(IOptions<MailSettings> _mailSettings)
        {
            mailSettings = _mailSettings.Value;
        }

        public async Task SendContactUsEmail(ContactUsEmail contactUsEmail)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(contactUsEmail.sendToEmail));
            email.Subject = " YBOY Contact ";
            var builder = new BodyBuilder();
            builder.HtmlBody = $" Dear {contactUsEmail.name} Thank you for using our website.<br/> " +
              contactUsEmail.body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendAcceptedOrderMail(ReceivedMail receivedMail)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(receivedMail.email));
            email.Subject = " YBOY ";
            var builder = new BodyBuilder();
            builder.HtmlBody = $" Dear {receivedMail.name} Thank you for using our website.<br/> " +
                "We have received your order and it is being processed.<br/> ";
              
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task Sendbill(billMail billMail)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(billMail.user_email));
            email.Subject = " YBOY ";
            var builder = new BodyBuilder();
            builder.HtmlBody = $" Dear {billMail.name} Thank you for using our website.<br/> " +
                "<hr> "+
                $"<p style='color:red; font-weight:bold;'>Total Amount : {billMail.total}</p>";

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
