using MyResume.Business.DTOs.SocialMediaDTOs;
using MyResume.Business.DTOs.SummaryDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.SummaryServices
{
    public interface ISummaryServices
    {
        Task<IResult> AddAsync(SummaryCreateDTO summaryCreateDTO);

        Task<IDataResult<List<SummaryListDTO>>> GetAllAsync();


        Task<IDataResult<SummaryDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(SummaryUpdateDTO summaryUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
