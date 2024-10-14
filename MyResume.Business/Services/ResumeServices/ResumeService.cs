using Mapster;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.ResumeDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.ResumeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.ResumeServices
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository _resumeRepository;

        public ResumeService(IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
        }

        public async Task<IResult> AddAsync(ResumeCreateDTO resumeCreateDTO)
        {
            var newResume = resumeCreateDTO.Adapt<Resume>();

            await _resumeRepository.AddAsync(newResume);
            await _resumeRepository.SaveChangeAsync();
            return new SuccsesResult("Resume Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingResume = await _resumeRepository.GetByIdAsync(id);

            if (deletingResume == null) { return new ErorResult("Silinecek Resume Bulunamadı"); }
            try
            {
                await _resumeRepository.DeleteAsync(deletingResume);
                await _resumeRepository.SaveChangeAsync();
                return new SuccsesResult("Resume Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<ResumeListDTO>>> GetAllAsync()
        {
            var resumes = await _resumeRepository.GetAllAsync(x => x.CreatedDate, false);

            var featurelistDto = resumes.Adapt<List<ResumeListDTO>>();
            if (resumes.Count() <= 0)
            {
                return new ErorDataResult<List<ResumeListDTO>>(featurelistDto, "Resume Listeleme Başarısız");
            }

            return new SuccsessDataResult<List<ResumeListDTO>>(featurelistDto, "Resume Listeleme Başarılı");
        }

        public async Task<IDataResult<ResumeDTO>> GetByIdAsync(Guid id)
        {
            var resume = await _resumeRepository.GetByIdAsync(id);

            if (resume is null)
            {
                return new ErorDataResult<ResumeDTO>(resume.Adapt<ResumeDTO>(), "Resume Bulunamadı");
            }

            return new SuccsessDataResult<ResumeDTO>(resume.Adapt<ResumeDTO>(), "Resume Bulundu");
        }

        public async Task<IResult> UpdateAsync(ResumeUpdateDTO resumeUpdateDTO)
        {
            var updatingResume = await _resumeRepository.GetByIdAsync(resumeUpdateDTO.Id);

            if (updatingResume is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedFeature = resumeUpdateDTO.Adapt(updatingResume);
                await _resumeRepository.UpdateAsync(updatedFeature);
                await _resumeRepository.SaveChangeAsync();
                return new SuccsesResult("Resume Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }
    }
}
