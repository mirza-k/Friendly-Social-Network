using FriendlyRS1.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyRS1.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        public SendGridEmailSender(IOptions<EmailSenderOptions> options)
        {
            this.Options = options.Value;
        }

        public EmailSenderOptions Options { get; set; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, email, subject, message);
        }

        public Task Execute(string apiKey, string to, string subject, string message)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Options.SenderEmail, Options.SendGridName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
        };
            msg.AddTo(new EmailAddress(to));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
