using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.AboutServices;
using MyResume.Business.Services.ResumeServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminAboutVMs;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminResumeVMs;

namespace MyResume.UI.Models.ViewComponents
{
    public class _ExperinceComponentPartial : ViewComponent
    {
        private readonly IResumeService _resumeService;

        public _ExperinceComponentPartial(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            ViewBag.resumeTitle = "Resume";
            ViewBag.resumeDesciprtion = "Kendinizle ilgili bilgi girebilirsiniz.";

            var result = await _resumeService.GetAllAsync();

            if (!result.IsSuccess)
            {

                return View(result.Data.Adapt<List<AdminResumeListVM>>());
            }

            return View(result.Data.Adapt<List<AdminResumeListVM>>());

        }
    }
}
