using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.ResumeDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.ResumeServices
{
    public interface IResumeService 
    {
        Task<IResult> AddAsync(ResumeCreateDTO resumeCreateDTO);

        Task<IDataResult<List<ResumeListDTO>>> GetAllAsync();


        Task<IDataResult<ResumeDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(ResumeUpdateDTO resumeUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
