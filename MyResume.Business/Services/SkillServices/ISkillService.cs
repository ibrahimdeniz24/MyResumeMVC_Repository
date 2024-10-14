using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.SkillDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.SkillServices
{
    public interface ISkillService
    {
        Task<IResult> AddAsync(SkillCreateDTO skillCreateDTO);

        Task<IDataResult<List<SkillListDTO>>> GetAllAsync();


        Task<IDataResult<SkillDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(SkillUpdateDTO skillUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
