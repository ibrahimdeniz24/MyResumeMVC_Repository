using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.ReCAPTCHAServices
{
    public interface IReCAPTCHAService
    {
        Task<bool> ValidateCaptchaAsync(string captchaResponse);
    }
}
