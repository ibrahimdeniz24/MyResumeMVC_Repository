using Hangfire;
using MyResume.Business.Services.HangFireServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.FeatureServices
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
