using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.SocialMediaDTOs;
using MyResume.Business.Services.SocialMediaServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminSocialMediaVMs;


namespace MyResume.UI.Areas.Admin.Controllers
{
    public class SocialMediaController : AdminBaseController
    {
        private readonly ISocialMediaService _service;

        public SocialMediaController(ISocialMediaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminSocialMediaListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminSocialMediaListVM>>());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminSocialMediaCreateVM adminSocialMedaiCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(adminSocialMedaiCreateVM);

            }

            var skillCreateDTO = adminSocialMedaiCreateVM.Adapt<SocialMediaCreateDTO>();
            var result = await _service.AddAsync(skillCreateDTO);

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminSocialMedaiCreateVM);
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);

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
            var result = await _service.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminSocialMediaUpdateVM>());

        }

        [HttpPost]
        public async Task<ActionResult> Update(AdminSocialMediaUpdateVM adminSocialMediaUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(adminSocialMediaUpdateVM);
            }
            var result = await _service.UpdateAsync(adminSocialMediaUpdateVM.Adapt<SocialMediaUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminSocialMediaUpdateVM);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }
    }
}
