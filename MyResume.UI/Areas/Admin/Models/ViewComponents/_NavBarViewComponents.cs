using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.AdminServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminAdminVMs;

namespace MyResume.UI.Areas.Admin.Models.ViewComponents
{
    public class _NavBarViewComponents :ViewComponent
    {
        private readonly IAdminService _adminService;
    

        public _NavBarViewComponents(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var admin = await _adminService.GetCurrentAdminAsync();

            var adminVm = (admin.Data).Adapt<AdminAdminVM>();

            return View(adminVm); // "Default" view'ine admin adını gönderiyoruz.
        }

    }
}
