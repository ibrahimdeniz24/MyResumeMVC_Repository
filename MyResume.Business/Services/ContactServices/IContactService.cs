using MyResume.Business.DTOs.AboutDTOs;
using MyResume.Business.DTOs.ContactDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.ContactServices
{
    public interface IContactService
    {
        Task<IResult> AddAsync(ContactCreateDTO contactCreateDTO );

        Task<IDataResult<List<ContactListDTO>>> GetAllAsync();


        Task<IDataResult<ContactDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(ContactUpdateDTO contactUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
