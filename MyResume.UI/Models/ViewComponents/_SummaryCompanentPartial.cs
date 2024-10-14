using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.Services.SummaryServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminSummaryVMs;

namespace MyResume.UI.Models.ViewComponents
{
    public class _SummaryCompanentPartial : ViewComponent
    {

        private readonly ISummaryServices _summaryServices;

        public _SummaryCompanentPartial(ISummaryServices summaryServices)
        {
            _summaryServices = summaryServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var result = await _summaryServices.GetAllAsync();

            if (!result.IsSuccess)
            {

                return View(result.Data.Adapt<List<AdminSummaryListVM>>());
            }

            return View(result.Data.Adapt<List<AdminSummaryListVM>>());
        }

    }
}
