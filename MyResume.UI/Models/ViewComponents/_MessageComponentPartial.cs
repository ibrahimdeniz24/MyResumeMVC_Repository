using Mapster;
using Microsoft.AspNetCore.Mvc;
using MyResume.Business.DTOs.MessageDTOs;
using MyResume.Business.Services.MessageServices;

using MyResume.UI.Models.ViewModels.MessageVM;

namespace MyResume.UI.Models.ViewComponents
{
    public class _MessageComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;

        public _MessageComponentPartial(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Boş bir ViewModel döndürerek formun ilk açılışında kullanılmasını sağlar.
            var model = new MessageCreateVM();
            return View(model);
        }


    }

}


