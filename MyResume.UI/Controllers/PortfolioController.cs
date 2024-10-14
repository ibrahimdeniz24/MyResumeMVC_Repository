using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.PotfolioServices;
using MyResume.UI.Models.ViewModels.MessageVM;
using MyResume.UI.Models.ViewModels.PortfolioVM;

namespace MyResume.UI.Controllers
{
    public class PortfolioController : BaseController
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }

            var result = await _portfolioService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(); // Eğer sonuç bulunamazsa 404 döner
            }

            return View(result.Data.Adapt<PortfolioDetailVM>()); // Sonucu View'e gönderir
        }
    }
}
