using Microsoft.AspNetCore.Mvc;

namespace MyResume.UI.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
