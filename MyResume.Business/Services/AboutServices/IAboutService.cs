using MyResume.Business.DTOs.AboutDTOs;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.AboutServices
{
    public interface IAboutService
    {
        Task<IResult> AddAsync(AboutCreateDTO aboutCreateDTO);

        Task<IDataResult<List<AboutListDTO>>> GetAllAsync();


        Task<IDataResult<AboutDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(AboutUpdateDTO aboutUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
