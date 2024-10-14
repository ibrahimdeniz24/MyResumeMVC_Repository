using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.SkillDTOs;
using MyResume.Business.Services.SkillServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminSkillVMs;


namespace MyResume.UI.Areas.Admin.Controllers
{
    public class SkillController : AdminBaseController
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _skillService.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminSkillListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminSkillListVM>>());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminSkillCreateVM adminSkillCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(adminSkillCreateVM);

            }

            var skillCreateDTO = adminSkillCreateVM.Adapt<SkillCreateDTO>();
            var result = await _skillService.AddAsync(skillCreateDTO);

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminSkillCreateVM);
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _skillService.DeleteAsync(id);

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
            var result = await _skillService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminSkillUpdateVM>());

        }

        [HttpPost]
        public async Task<ActionResult> Update(AdminSkillUpdateVM adminSkillUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(adminSkillUpdateVM);
            }
            var result = await _skillService.UpdateAsync(adminSkillUpdateVM.Adapt<SkillUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminSkillUpdateVM);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }
    }
}
