using Mapster;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.PortfolioDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.PortfolioRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.PotfolioServices
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<IResult> AddAsync(PortfolioCreateDTO portfolioCreateDTO)
        {
            var newPortfolio = portfolioCreateDTO.Adapt<Portfolio>();

            await _portfolioRepository.AddAsync(newPortfolio);
            await _portfolioRepository.SaveChangeAsync();
            return new SuccsesResult("Portfolio Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingPortfolio = await _portfolioRepository.GetByIdAsync(id);

            if (deletingPortfolio == null) { return new ErorResult("Silinecek Portfolio Bulunamadı"); }
            try
            {
                await _portfolioRepository.DeleteAsync(deletingPortfolio);
                await _portfolioRepository.SaveChangeAsync();
                return new SuccsesResult("Portfolio Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<PortfolioListDTO>>> GetAllAsync()
        {
            var portfolios = await _portfolioRepository.GetAllAsync(x => x.CreatedDate, false);

            var featurelistDto = portfolios.Adapt<List<PortfolioListDTO>>();
            if (portfolios.Count() <= 0)
            {
                return new ErorDataResult<List<PortfolioListDTO>>(featurelistDto, "Portfolio Listeleme Başarısız");
            }

            return new SuccsessDataResult<List<PortfolioListDTO>>(featurelistDto, "Portfolio Listeleme Başarılı");
        }

        public async Task<IDataResult<PortfolioDTO>> GetByIdAsync(Guid id)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(id);

            if (portfolio is null)
            {
                return new ErorDataResult<PortfolioDTO>(portfolio.Adapt<PortfolioDTO>(), "Portfolio Bulunamadı");
            }

            return new SuccsessDataResult<PortfolioDTO>(portfolio.Adapt<PortfolioDTO>(), "Portfolio Bulundu");
        }

        public async Task<IResult> UpdateAsync(PortfolioUpdateDTO portfolioUpdateDTO)
        {
            var updatingPortfolio = await _portfolioRepository.GetByIdAsync(portfolioUpdateDTO.Id);

            if (updatingPortfolio is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedFeature = portfolioUpdateDTO.Adapt(updatingPortfolio);
                await _portfolioRepository.UpdateAsync(updatedFeature);
                await _portfolioRepository.SaveChangeAsync();
                return new SuccsesResult("Portfolio Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }
    }
}
