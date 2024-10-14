using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.PotfolioServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminPortfolioVMs;

namespace MyResume.UI.Models.ViewComponents
{
    public class _PortfolioComponentPartial : ViewComponent
    {
        //public IViewComponentResult Invoke() { return View(); }
        private readonly IPortfolioService _portfolioService;

        public _PortfolioComponentPartial(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _portfolioService.GetAllAsync();

            if (!result.IsSuccess)
            {

                return View(result.Data.Adapt<List<AdminPortfolioListVM>>());
            }

            return View(result.Data.Adapt<List<AdminPortfolioListVM>>());


        }
    }
}
