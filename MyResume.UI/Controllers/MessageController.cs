using Hangfire;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.MessageDTOs;
using MyResume.Business.Services.EmailServices;
using MyResume.Business.Services.MessageServices;
using MyResume.Business.Services.ReCAPTCHAServices;
using MyResume.Domain;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminMessageVMs;
using MyResume.UI.Models.ViewModels.MessageVM;
using Newtonsoft.Json;
using NuGet.Common;

namespace MyResume.UI.Controllers;

public class MessageController : BaseController
{
    private readonly IMessageService _messageService;
    private readonly IEmailService _emailService;
    private readonly IReCAPTCHAService _reCAPTCHAService;



    const string mail = "ibrahimdeniz24@hotmail.com";
    public MessageController(IMessageService messageService, IEmailService emailService, IReCAPTCHAService reCAPTCHAService)
    {
        _messageService = messageService;
        _emailService = emailService;
        _reCAPTCHAService = reCAPTCHAService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(MessageCreateVM messageCreateVM)
    {

        // Recaptcha token kontrolü
        if (!string.IsNullOrEmpty(messageCreateVM.RecaptchaToken))
        {


            if (!ModelState.IsValid)
            {
                return View(messageCreateVM);
            }
            // reCAPTCHA doğrulaması
            var isCaptchaValid = await _reCAPTCHAService.ValidateCaptchaAsync(messageCreateVM.RecaptchaToken);

            if (!isCaptchaValid)
            {
                ModelState.AddModelError(string.Empty, "reCAPTCHA doğrulaması başarısız oldu.");
                return View("Eror");
            }

            var messageCreateDTO = messageCreateVM.Adapt<MessageCreateDTO>();

            var result = await _messageService.AddAsync(messageCreateDTO);
            if (!result.IsSuccess)
            {
                ErorNotyf(result.Message);
                return View(messageCreateVM);
            }


            RedirectToAction("MessageSent");

            BackgroundJob.Enqueue(() => _emailService.SendEmailAsync(
                   messageCreateVM.Email,
                   "Yeni İletişim Formu Mesajı",
                   $"<p>Gönderen: {messageCreateVM.NameSurname}</p><p>Email: {messageCreateVM.Email}</p><p>Mesaj: Mesajınız Başarı ile Gönderilmiştir. </p>"
               ));

            BackgroundJob.Enqueue(() => _emailService.SendEmailAsync(
                 mail,
                 "Yeni İletişim Formu Mesajı",
                 $"<p>Gönderen: {messageCreateVM.NameSurname}</p><p>Email: {messageCreateVM.Email}</p><p>Mesaj:  {messageCreateVM.MessageDetail} </p>"
             ));

            SuccessNotyf(result.Message);
            return View("MessageSent");
        }
        return View("Error"); // Hata sayfasına yönlendirme
    }

    public IActionResult MessageSent()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }


}
