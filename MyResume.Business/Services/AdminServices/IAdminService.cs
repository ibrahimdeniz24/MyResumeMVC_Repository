using MyResume.Business.DTOs.AdminDTOs;
using MyResume.Business.DTOs.ContactDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.AdminServices
{
    public interface IAdminService
    {
        Task<IResult> AddAsync(AdminCreateDTO adminCreateDTO);

        Task<IDataResult<List<AdminListDTO>>> GetAllAsync();


        Task<IDataResult<AdminDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(AdminUpdateDTO adminUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
