using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.AboutServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminAboutVMs;


namespace MyResume.UI.Models.ViewComponents
{
    public class _AboutComponentPartial :ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _AboutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            ViewBag.aboutTitle = "Hakkımda";
            ViewBag.AboutDesciprtion = "Ben bir .NET Developer olarka çalışmaktayım";

            var result = await _aboutService.GetAllAsync();

            if (!result.IsSuccess)
            {

                return View(result.Data.Adapt<List<AdminAboutListVM>>());
            }

            return View(result.Data.Adapt<List<AdminAboutListVM>>());

        }
    }
}
