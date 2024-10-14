using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.SummaryDTOs;
using MyResume.Business.Services.SummaryServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminSummaryVMs;

namespace MyResume.UI.Areas.Admin.Controllers
{
    
    public class SummaryController : AdminBaseController
    {
        private readonly ISummaryServices _summaryServices;

        public SummaryController(ISummaryServices summaryServices)
        {
            _summaryServices = summaryServices;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _summaryServices.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminSummaryListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminSummaryListVM>>());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminSummaryCreateVM adminSummaryCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(adminSummaryCreateVM);

            }

            var summaryCreateDTO = adminSummaryCreateVM.Adapt<SummaryCreateDTO>();
            var result = await _summaryServices.AddAsync(summaryCreateDTO);

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminSummaryCreateVM);
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _summaryServices.DeleteAsync(id);

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
            var result = await _summaryServices.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminSummaryUpdateVM>());

        }

        [HttpPost]
        public async Task<ActionResult> Update(AdminSummaryUpdateVM adminSummaryUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(adminSummaryUpdateVM);
            }
            var result = await _summaryServices.UpdateAsync(adminSummaryUpdateVM.Adapt<SummaryUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminSummaryUpdateVM);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

    }
}
