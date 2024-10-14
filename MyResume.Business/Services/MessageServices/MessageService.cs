using Mapster;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.MessageDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.MessageRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepositories _messageRepositories;

        public MessageService(IMessageRepositories messageRepositories)
        {
            _messageRepositories = messageRepositories;
        }

        public async Task<IResult> AddAsync(MessageCreateDTO messageCreateDTO)
        {
            var newMessage = messageCreateDTO.Adapt<Message>();

            await _messageRepositories.AddAsync(newMessage);
            await _messageRepositories.SaveChangeAsync();
            return new SuccsesResult("Message Ekleme Başarılı");

        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingMessage = await _messageRepositories.GetByIdAsync(id);

            if (deletingMessage == null) { return new ErorResult("Silinecek Message Bulunamadı"); }
            try
            {
                await _messageRepositories.DeleteAsync(deletingMessage);
                await _messageRepositories.SaveChangeAsync();
                return new SuccsesResult("Message Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<MessageListDTO>>> GetAllAsync()
        {
            var messages = await _messageRepositories.GetAllAsync(x => x.CreatedDate, false);

            var messageListDto = messages.Adapt<List<MessageListDTO>>();
            if (messages.Count() <= 0)
            {
                return new ErorDataResult<List<MessageListDTO>>(messageListDto, "Message Listeleme Başarısız");
            }

            return new SuccsessDataResult<List<MessageListDTO>>(messageListDto, "Message Listeleme Başarılı");
        }

        public async Task<IDataResult<MessageDTO>> GetByIdAsync(Guid id)
        {
            var message = await _messageRepositories.GetByIdAsync(id);

            if (message is null)
            {
                return new ErorDataResult<MessageDTO>(message.Adapt<MessageDTO>(), "Message Bulunamadı");
            }

            return new SuccsessDataResult<MessageDTO>(message.Adapt<MessageDTO>(), "Message Bulundu");
        }

        public async Task<IResult> UpdateAsync(MessageUpdateDTO messageUpdateDTO)
        {
            var updatingMessage = await _messageRepositories.GetByIdAsync(messageUpdateDTO.Id);

            if (updatingMessage is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedMessage = messageUpdateDTO.Adapt(updatingMessage);
                await _messageRepositories.UpdateAsync(updatingMessage);
                await _messageRepositories.SaveChangeAsync();
                return new SuccsesResult("Message Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }
    }
}
