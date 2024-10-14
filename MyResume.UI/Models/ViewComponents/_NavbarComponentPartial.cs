using Microsoft.AspNetCore.Mvc;

namespace MyResume.UI.Models.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
