using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.PortfolioDTOs;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.PotfolioServices
{
    public interface IPortfolioService
    {
        Task<IResult> AddAsync(PortfolioCreateDTO portfolioCreateDTO);

        Task<IDataResult<List<PortfolioListDTO>>> GetAllAsync();


        Task<IDataResult<PortfolioDTO>> GetByIdAsync(Guid id);

        Task<IResult> UpdateAsync(PortfolioUpdateDTO portfolioUpdateDTO);

        Task<IResult> DeleteAsync(Guid id);
    }
}
