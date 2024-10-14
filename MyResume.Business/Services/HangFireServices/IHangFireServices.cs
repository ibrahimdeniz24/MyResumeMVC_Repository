using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.HangFireServices
{
    public interface IHangFireServices
    {
        void SendEmailJob(string toEmail, string subject, string body);
    }
}
