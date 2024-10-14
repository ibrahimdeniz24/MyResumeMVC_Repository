using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.SocialMediaDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.SocialMediaServices
{
    public interface ISocialMediaService
    {
        Task<IResult> AddAsync(SocialMediaCreateDTO socialMediaCreateDTO);

        Task<IDataResult<List<SocialMediaListDTO>>> GetAllAsync();


        Task<IDataResult<SocialMediaDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(SocialMediaUpdateDTO socialMediaUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
