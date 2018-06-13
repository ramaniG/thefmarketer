using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Text;

namespace Fmarketer.Email
{
    class BaseEmailSmtp
    {
        protected SmtpClient MessagingSmtpClient { get; set; }
        protected MailMessage Mail { get; set; }
        protected IConfiguration configuration;

        public BaseEmailSmtp(string from, string to, string displayName, IConfiguration configuration)
        {
            PrepareMailMessage(from, to, displayName);
            this.configuration = configuration;
        }

        protected void PrepareMailMessage(string from, string to, string displayName)
        {
            MailAddress From = new MailAddress(from, displayName, Encoding.UTF8);
            MailAddress To = new MailAddress(to);
            Mail = new MailMessage(From, To)
            {
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure,
                SubjectEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };
        }

        protected void SetMailConfigMessage(string configSet)
        {
            this.Mail.Headers.Add("X-SES-CONFIGURATION-SET", configSet);
        }

        protected void SendEmail()
        {
            try
            {
                MessagingSmtpClient.Send(Mail);
                Mail.Dispose();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                Mail.Dispose();
                MessagingSmtpClient.Dispose();
            }
        }
    }
}
