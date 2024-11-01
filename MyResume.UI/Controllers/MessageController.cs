using Hangfire;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.MessageDTOs;
using MyResume.Business.Services.EmailServices;
using MyResume.Business.Services.MessageServices;
using MyResume.UI.Areas.Admin.Models.AdminVMs.AdminMessageVMs;
using MyResume.UI.Models.ViewModels.MessageVM;

namespace MyResume.UI.Controllers;

public class MessageController :BaseController
{
    private readonly IMessageService _messageService;
    private readonly IEmailService _emailService;

    const string mail = "ibrahimdeniz24@hotmail.com";
    public MessageController(IMessageService messageService, IEmailService emailService)
    {
        _messageService = messageService;
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(MessageCreateVM messageCreateVM)
    {
        if (!ModelState.IsValid)
        {
            return View(messageCreateVM);
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

    public IActionResult MessageSent()
    {
        return View();
    }


}
