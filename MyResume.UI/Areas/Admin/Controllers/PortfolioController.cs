using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.AboutDTOs;
using MyResume.Business.DTOs.PortfolioDTOs;
using MyResume.Business.Services.PotfolioServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminAboutVMs;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminPortfolioVMs;

namespace MyResume.UI.Areas.Admin.Controllers
{
    public class PortfolioController : AdminBaseController
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _portfolioService.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminPortfolioListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminPortfolioListVM>>());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminPortfolioCreateVM adminPortfolioCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(adminPortfolioCreateVM);

            }

            var portfolioCreateDTO = adminPortfolioCreateVM.Adapt<PortfolioCreateDTO>();
            var result = await _portfolioService.AddAsync(portfolioCreateDTO);

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminPortfolioCreateVM);
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _portfolioService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _portfolioService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminPortfolioUpdateVM>());

        }

        [HttpPost]
        public async Task<ActionResult> Update(AdminPortfolioUpdateVM adminPortfolioUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(adminPortfolioUpdateVM);
            }
            var result = await _portfolioService.UpdateAsync(adminPortfolioUpdateVM.Adapt<PortfolioUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminPortfolioUpdateVM);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }
    }
}
