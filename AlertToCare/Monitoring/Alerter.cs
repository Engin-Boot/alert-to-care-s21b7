using System.Net;
using System.Net.Mail;

namespace AlertToCare.Monitoring
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Alerter
    {
        public interface IAlerter
        {
            bool Alert(string message);
        }
        public class EmailAlert : IAlerter
        {
            public bool Alert(string message)
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("casestudyb217@gmail.com", "Case@217"),
                    EnableSsl = true,
                };
                smtpClient.Send("casestudyb217@gmail.com", "casestudyb217@gmail.com", "Patient Vital Alert", message);

                return true;
            }
        }
    }
}
