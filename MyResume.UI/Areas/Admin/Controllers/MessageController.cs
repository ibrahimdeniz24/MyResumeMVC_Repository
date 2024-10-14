using Hangfire;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.MessageDTOs;
using MyResume.Business.Services.EmailServices;
using MyResume.Business.Services.MessageServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminMessageVMs;
using MyResume.UI.Models.ViewModels.MessageVM;

namespace MyResume.UI.Areas.Admin.Controllers
{
    public class MessageController : AdminBaseController
    {
        private readonly IMessageService _messageService;
        private readonly IEmailService _emailService;

        public MessageController(IMessageService messageService, IEmailService emailService)
        {
            _messageService = messageService;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _messageService.GetAllAsync();

            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminMessageListVM>>());
            }
            SuccessNotyf(result.Message);
            return View(result.Data.Adapt<List<AdminMessageListVM>>());
        }

    }
}
