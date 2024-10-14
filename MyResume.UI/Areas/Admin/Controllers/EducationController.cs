using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.EducationDTOs;
using MyResume.Business.Services.EducationServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminEducationVMs;

namespace MyResume.UI.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _educationService.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminEducationListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminEducationListVM>>());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminEducationCreateVM adminEducationCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(adminEducationCreateVM);

            }

            var summaryCreateDTO = adminEducationCreateVM.Adapt<EducationCreateDTO>();
            var result = await _educationService.AddAsync(summaryCreateDTO);

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminEducationCreateVM);
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _educationService.DeleteAsync(id);

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
            var result = await _educationService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminEducationUpdateVM>());

        }

        [HttpPost]
        public async Task<ActionResult> Update(AdminEducationUpdateVM adminEducationUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(adminEducationUpdateVM);
            }
            var result = await _educationService.UpdateAsync(adminEducationUpdateVM.Adapt<EducationUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminEducationUpdateVM);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }


    }
}
