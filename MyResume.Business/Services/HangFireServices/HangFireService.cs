using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.HangFireServices
{
    public class HangFireService : IHangFireServices
    {
        public void SendEmailJob(string toEmail, string subject, string body)
        {
            BackgroundJob.Enqueue(() => SendEmail(toEmail, subject, body));
        }


        public void SendEmail(string toEmail, string subject, string body)
        {
            // Burada e-posta gönderme kodunuzu ekleyin
            // Örneğin: EmailService.SendEmail(toEmail, subject, body);
        }
    }
}
