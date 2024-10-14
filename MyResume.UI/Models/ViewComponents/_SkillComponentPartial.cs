using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.SkillServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminSkillVMs;

namespace MyResume.UI.Models.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        private readonly ISkillService _skillService;

        public _SkillComponentPartial(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _skillService.GetAllAsync();

            if (!result.IsSuccess)
            {

                return View(result.Data.Adapt<List<AdminSkillListVM>>());
            }

            return View(result.Data.Adapt<List<AdminSkillListVM>>());
        }
    }
}
