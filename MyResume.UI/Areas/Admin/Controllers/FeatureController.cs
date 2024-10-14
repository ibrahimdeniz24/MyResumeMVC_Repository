using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.Services.FeatureServices;
using MyResume.UI.Models.AdminVMs.AdminFeatureVMs;


namespace MyResume.UI.Areas.Admin.Controllers
{
    public class FeatureController : AdminBaseController

    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _featureService.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminFeatureListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminFeatureListVM>>());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminFeatureCreateVM featureCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(featureCreateVM);

            }

            var featureCreateDTO = featureCreateVM.Adapt<FeatureCreateDTO>();
            var result = await _featureService.AddAsync(featureCreateDTO);

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(featureCreateVM);
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _featureService.DeleteAsync(id);

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
            var result = await _featureService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminFeatureUpdateVM>());

        }

        [HttpPost]
        public async Task<ActionResult> Update(AdminFeatureUpdateVM featureUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(featureUpdateVM);
            }
            var result = await _featureService.UpdateAsync(featureUpdateVM.Adapt<FeatureUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(featureUpdateVM);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

    }


}
