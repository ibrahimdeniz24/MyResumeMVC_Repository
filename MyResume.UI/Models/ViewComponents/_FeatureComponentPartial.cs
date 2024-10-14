using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.FeatureServices;
using MyResume.Domain.Utilities.Concretes;
using MyResume.UI.Models.AdminVMs.AdminFeatureVMs;

namespace MyResume.UI.Models.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _FeatureComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _featureService.GetAllAsync();

            if (!result.IsSuccess)
            {
                
                return View(result.Data.Adapt<List<AdminFeatureListVM>>());
            }
            
            return View(result.Data.Adapt<List<AdminFeatureListVM>>());
        }


    }
}
