using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.AboutDTOs;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.Services.AboutServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminAboutVMs;
using MyResume.UI.Extantions;
using MyResume.UI.Models.AdminVMs.AdminFeatureVMs;

namespace MyResume.UI.Areas.Admin.Controllers
{
    public class AboutController : AdminBaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _aboutService.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminAboutListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminAboutListVM>>());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminAboutCreateVM adminAboutCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(adminAboutCreateVM);

            }

            var aboutCreateDTO = adminAboutCreateVM.Adapt<AboutCreateDTO>();
          
            if(adminAboutCreateVM.NewPicture == null || adminAboutCreateVM.NewPicture.Length == 0)
            {
                return BadRequest("Geçerli bir fotoğraf yükleyin.");
            }
                aboutCreateDTO.ProfilePicture =  await adminAboutCreateVM.NewPicture.StringToByteArrayAsync();

            var result = await _aboutService.AddAsync(aboutCreateDTO);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminAboutCreateVM);
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _aboutService.DeleteAsync(id);

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
            var result = await _aboutService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminAboutUpdateVM>());

        }

        [HttpPost]
        public async Task<ActionResult> Update(AdminAboutUpdateVM adminAboutUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(adminAboutUpdateVM);
            }
            var result = await _aboutService.UpdateAsync(adminAboutUpdateVM.Adapt<AboutUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminAboutUpdateVM);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }
    }
}
