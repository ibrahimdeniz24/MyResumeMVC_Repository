using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.AdminServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminAdminVMs;

namespace MyResume.UI.Areas.Admin.Models.ViewComponents
{
    public class _ProfileDetailsViewComponents :ViewComponent
    {
        private readonly IAdminService _adminService;

        public _ProfileDetailsViewComponents(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var result = await _adminService.GetCurrentAdminAsync();

            if (!result.IsSuccess)
            {

                return View(result.Data.Adapt<AdminAdminVM>());
            }

            return View(result.Data.Adapt<AdminAdminVM>());

        }

    }
}
