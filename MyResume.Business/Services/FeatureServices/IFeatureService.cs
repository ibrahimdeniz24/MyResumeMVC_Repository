using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.AppContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<IResult> AddAsync(FeatureCreateDTO featureCreateDTO);

        Task<IDataResult<List<FeatureListDTO>>> GetAllAsync();


        Task<IDataResult<FeatureDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(FeatureUpdateDTO featureUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
