using Microsoft.AspNetCore.Mvc;

namespace MyResume.UI.Models.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            
            
            return View(); 
        
        }
    }
}
