using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.AboutDTOs;
using MyResume.Business.DTOs.ContactDTOs;
using MyResume.Business.Services.ContactServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminContactVMs;

namespace MyResume.UI.Areas.Admin.Controllers
{
    public class ContactController : AdminBaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _contactService.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminContactListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminContactListVM>>());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminContactCreateVM adminContactCreateVM)
        {
            if (!ModelState.IsValid)
            {

                return View(adminContactCreateVM);

            }

            var contactCreateDTO = adminContactCreateVM.Adapt<ContactCreateDTO>();
            var result = await _contactService.AddAsync(contactCreateDTO);

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminContactCreateVM);
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _contactService.DeleteAsync(id);

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
            var result = await _contactService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<AdminContactUpdateVM>());

        }

        [HttpPost]
        public async Task<ActionResult> Update(AdminContactUpdateVM adminContactUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(adminContactUpdateVM);
            }
            var result = await _contactService.UpdateAsync(adminContactUpdateVM.Adapt<ContactUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(adminContactUpdateVM);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }
    }
}
