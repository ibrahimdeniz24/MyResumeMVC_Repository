using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.MessageDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.MessageServices
{
    public interface IMessageService
    {
        Task<IResult> AddAsync(MessageCreateDTO messageCreateDTO);

        Task<IDataResult<List<MessageListDTO>>> GetAllAsync();


        Task<IDataResult<MessageDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(MessageUpdateDTO messageUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
