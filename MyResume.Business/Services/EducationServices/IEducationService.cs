using MyResume.Business.DTOs.EducationDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.EducationServices
{
    public interface IEducationService 
    {
        Task<IResult> AddAsync(EducationCreateDTO educationCreateDTO);

        Task<IDataResult<List<EducationListDTO>>> GetAllAsync();


        Task<IDataResult<EducationDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(EducationUpdateDTO educationUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
