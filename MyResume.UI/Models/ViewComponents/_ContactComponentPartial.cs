using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.ContactServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminContactVMs;


namespace MyResume.UI.Models.ViewComponents
{

    public class _ContactComponentPartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _ContactComponentPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            ViewBag.ContactHead = "Bana Ulaşın";
            ViewBag.ContactDescription = "Bana Neden ulaşsınlar ki ";
            var result = await _contactService.GetAllAsync();

            if (!result.IsSuccess)
            {

                return View(result.Data.Adapt<List<AdminContactListVM>>());
            }

            return View(result.Data.Adapt<List<AdminContactListVM>>());
        }
    }
}