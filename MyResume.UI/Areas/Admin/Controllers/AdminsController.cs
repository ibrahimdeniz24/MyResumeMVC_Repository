using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.AdminDTOs;
using MyResume.Business.Services.AdminServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminAdminVMs;
using MyResume.UI.Extantions;

namespace MyResume.UI.Areas.Admin.Controllers
{
    public class AdminsController : AdminBaseController
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Profile()
        {
            var adminDto = await _adminService.GetCurrentAdminAsync();


            var result = await _adminService.GetByIdAsync(adminDto.Data.Id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminAdminVM>());
        }


        public async Task<IActionResult> Update(Guid id)
        {

            var result = await _adminService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminAdminUpdateVM>());
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminAdminUpdateVM updateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(updateVM);
            }

            var adminDto = await _adminService.GetCurrentAdminAsync();
            updateVM.Id = adminDto.Data.Id;
            var adminUpdateDTO = updateVM.Adapt<AdminUpdateDTO>();
            if (updateVM.NewPicture == null || updateVM.NewPicture.Length == 0)
            {
                return BadRequest("Lütfen Geçerli Bir Fotoğraf Yükleyin");
            }

            adminUpdateDTO.ProfilePicture = await updateVM.NewPicture.StringToByteArrayAsync();


            var result = await _adminService.UpdateAsync(adminUpdateDTO);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(updateVM);
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");

        }
    }
}
