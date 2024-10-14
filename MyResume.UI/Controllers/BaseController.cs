using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.UI.Controllers
{
    public class BaseController : Controller
    {
        protected INotyfService notyfService => HttpContext.RequestServices.GetService(typeof(INotyfService)) as INotyfService;

        protected void SuccessNotyf(string message)
        {
            notyfService.Success(message);
        }


        protected void ErorNotyf(string message)
        {
            notyfService.Error(message);
        }

    }
}
