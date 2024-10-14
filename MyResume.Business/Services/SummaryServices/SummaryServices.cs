using Mapster;
using MyResume.Business.DTOs.SocialMediaDTOs;
using MyResume.Business.DTOs.SummaryDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.SummaryRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.SummaryServices
{
    public class SummaryServices : ISummaryServices
    {
        private readonly ISummaryRepository _summaryRepository;

        public SummaryServices(ISummaryRepository summaryRepository)
        {
            _summaryRepository = summaryRepository;
        }

        public async Task<IResult> AddAsync(SummaryCreateDTO summaryCreateDTO)
        {
            var newSummary = summaryCreateDTO.Adapt<Summary>();

            await _summaryRepository.AddAsync(newSummary);
            await _summaryRepository.SaveChangeAsync();
            return new SuccsesResult("Summary Ekleme Başarılı");

        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingSummary = await _summaryRepository.GetByIdAsync(id);

            if (deletingSummary == null) { return new ErorResult("Silinecek Summary Bulunamadı"); }
            try
            {
                await _summaryRepository.DeleteAsync(deletingSummary);
                await _summaryRepository.SaveChangeAsync();
                return new SuccsesResult("Summary Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<SummaryListDTO>>> GetAllAsync()
        {
            var summarys = await _summaryRepository.GetAllAsync(x => x.CreatedDate, false);

            var summarylistDto = summarys.Adapt<List<SummaryListDTO>>();
            if (summarys.Count() <= 0)
            {
                return new ErorDataResult<List<SummaryListDTO>>(summarylistDto, "Summary Listeleme Başarısız");
            }

            return new SuccsessDataResult<List<SummaryListDTO>>(summarylistDto, "Summary Listeleme Başarılı");

        }

        public async Task<IDataResult<SummaryDTO>> GetByIdAsync(Guid id)
        {
            var summary = await _summaryRepository.GetByIdAsync(id);

            if (summary is null)
            {
                return new ErorDataResult<SummaryDTO>(summary.Adapt<SummaryDTO>(), "Summary Bulunamadı");
            }

            return new SuccsessDataResult<SummaryDTO>(summary.Adapt<SummaryDTO>(), "Summary Bulundu");

        }

        public async Task<IResult> UpdateAsync(SummaryUpdateDTO summaryUpdateDTO)
        {
            var updatingSummary = await _summaryRepository.GetByIdAsync(summaryUpdateDTO.Id);

            if (updatingSummary is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedSummary = summaryUpdateDTO.Adapt(updatingSummary);
                await _summaryRepository.UpdateAsync(updatedSummary);
                await _summaryRepository.SaveChangeAsync();
                return new SuccsesResult("Summary Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }

        }
    }
}
