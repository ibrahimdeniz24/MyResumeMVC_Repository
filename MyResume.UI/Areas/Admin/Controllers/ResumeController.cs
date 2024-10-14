using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.ResumeDTOs;
using MyResume.Business.Services.ResumeServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminResumeVMs;

namespace MyResume.UI.Areas.Admin.Controllers
{
    public class ResumeController : AdminBaseController
    {
       private readonly IResumeService _service;

        public ResumeController(IResumeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminResumeListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminResumeListVM>>());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminResumeCreateVM adminResumeCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(adminResumeCreateVM);

            }

            var resumeCreateDTO = adminResumeCreateVM.Adapt<ResumeCreateDTO>();
            var result = await _service.AddAsync(resumeCreateDTO);

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminResumeCreateVM);
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
            return View(result.Data.Adapt<AdminResumeUpdateVM>());

        }

        [HttpPost]
        public async Task<ActionResult> Update(AdminResumeUpdateVM adminResumeUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(adminResumeUpdateVM);
            }
            var result = await _service.UpdateAsync(adminResumeUpdateVM.Adapt<ResumeUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminResumeUpdateVM);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }
    }
}
