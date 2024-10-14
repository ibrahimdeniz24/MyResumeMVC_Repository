using Microsoft.AspNetCore.Mvc;

namespace MyResume.UI.Models.ViewComponents
{
    public class _StatisticComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
