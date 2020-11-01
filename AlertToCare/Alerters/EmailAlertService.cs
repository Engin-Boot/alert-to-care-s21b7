using System;
using System.Net;
using System.Net.Mail;

namespace AlertToCare.Alerters
{
    public class EmailAlertService:IEmailAlerter
    {
        public object SendEmailVitalAlert(VitalAlertEmailFormat email)
        {
            try
            {
                var mailMessage = GetMailMessage(email);
                var smtpClient = GetEmailServerDetails();
                smtpClient.Send(mailMessage);
                return HttpStatusCode.OK;
            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
                return HttpStatusCode.NetworkAuthenticationRequired;
            }
        }

        private static MailMessage GetMailMessage(VitalAlertEmailFormat email)
        {
            var mailMessage = new MailMessage { From = GetFromAddress() };
            mailMessage.To.Add(GetToAddress());
            //mailMessage.To.Add("abc@gmail.com");
            mailMessage.Subject = email.Subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = email.Body;
            return mailMessage;
        }

        private static string GetToAddress()
        {
            return "casestudyb217@gmail.com";
        }

        private static MailAddress GetFromAddress()
        {
            return new MailAddress("casestudyb217@gmail.com");
        }

        private static SmtpClient GetEmailServerDetails()
        {
            var smtpClient = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = GetSenderEmailCredentials(),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            return smtpClient;
        }
        private static ICredentialsByHost GetSenderEmailCredentials()
        {
            return new NetworkCredential("casestudyb217@gmail.com".TrimEnd(), "Case@217".TrimEnd());
        }

    }
}
