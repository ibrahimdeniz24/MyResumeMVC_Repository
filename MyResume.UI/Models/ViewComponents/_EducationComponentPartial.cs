using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.EducationServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminEducationVMs;

namespace MyResume.UI.Models.ViewComponents
{
    public class _EducationComponentPartial : ViewComponent
    {
        private readonly IEducationService _educationService;

        public _EducationComponentPartial(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var result = await _educationService.GetAllAsync();

            if (!result.IsSuccess)
            {

                return View(result.Data.Adapt<List<AdminEducationListVM>>());
            }

            return View(result.Data.Adapt<List<AdminEducationListVM>>());
        }
    }
}