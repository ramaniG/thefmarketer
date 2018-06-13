using Fmarketer.Email.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Fmarketer.Email
{
    class GmailSmtp : BaseEmailSmtp
    {
        public GmailSmtp(string from, string to, string dispalyName, IConfiguration configurationService) : base(from, to, dispalyName, configurationService)
        {
            InitializeSMTPConfig();
        }

        public void SendEmailWithNormalTextBody(string body, string subject)
        {
            Mail.Body = body;
            Mail.Subject = subject;
            SendEmail();
        }

        public void SendEmailWithHTMLBody(string body, string subject)
        {
            AlternateView htmlBody = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            Mail.AlternateViews.Add(htmlBody);
            Mail.Subject = subject;
            SendEmail();
        }

        public void SendUserActivationEmailWithHTMLBody(EmailBodyData emailBodyData)
        {
            LinkedResource headerImage = new LinkedResource(emailBodyData.HeaderPath)
            {
                ContentId = Guid.NewGuid().ToString()
            };

            LinkedResource footerImage = new LinkedResource(emailBodyData.FooterPath)
            {
                ContentId = Guid.NewGuid().ToString()
            };

            string htmlBody = string.Format(emailBodyData.Body, headerImage.ContentId, emailBodyData.Name, emailBodyData.UserName, emailBodyData.LinkAddress, footerImage.ContentId);
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(headerImage);
            alternateView.LinkedResources.Add(footerImage);
            Mail.AlternateViews.Add(alternateView);
            Mail.Subject = emailBodyData.Subject;
            SendEmail();
        }

        public void SendResetPasswordEmailWithHTMLBody(EmailBodyData emailBodyData)
        {
            LinkedResource footerImage = new LinkedResource(emailBodyData.FooterPath)
            {
                ContentId = Guid.NewGuid().ToString()
            };

            string htmlBody = string.Format(emailBodyData.Body, emailBodyData.Name, emailBodyData.LinkAddress, footerImage.ContentId);
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(footerImage);
            Mail.AlternateViews.Add(alternateView);
            Mail.Subject = emailBodyData.Subject;
            SendEmail();
        }

        private void InitializeSMTPConfig()
        {
            var password = configuration.GetSection("GMailSMTPPassword").Value;
            var user = configuration.GetSection("GMailSMTPUsername").Value;
            var port = configuration.GetSection("GMailSMTPPort").Value;
            var host = configuration.GetSection("GmailSMTPHost").Value;
            var timeOut = configuration.GetSection("GMailSMTPTimeOut").Value;

            MessagingSmtpClient = new SmtpClient
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Port = Int32.Parse(port),
                Host = host,
                Timeout = Int32.Parse(timeOut),
                Credentials = new NetworkCredential(user, password)
            };

            MessagingSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }
    }
}
