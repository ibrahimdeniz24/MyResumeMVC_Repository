using Mapster;
using MyResume.Business.DTOs.EducationDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.EducationRepositories;

namespace MyResume.Business.Services.EducationServices
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<IResult> AddAsync(EducationCreateDTO educationCreateDTO)
        {
            var newEducation = educationCreateDTO.Adapt<Education>();

            await _educationRepository.AddAsync(newEducation);
            await _educationRepository.SaveChangeAsync();
            return new SuccsesResult("Education Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingEducation = await _educationRepository.GetByIdAsync(id);

            if (deletingEducation == null) { return new ErorResult("Silinecek Education Bulunamadı"); }
            try
            {
                await _educationRepository.DeleteAsync(deletingEducation);
                await _educationRepository.SaveChangeAsync();
                return new SuccsesResult("Education Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<EducationListDTO>>> GetAllAsync()
        {
            var educations = await _educationRepository.GetAllAsync(x => x.CreatedDate, false);

            var educationlistDto = educations.Adapt<List<EducationListDTO>>();
            if (educations.Count() <= 0)
            {
                return new ErorDataResult<List<EducationListDTO>>(educationlistDto, "Education Listeleme Başarısız");
            }

            return new SuccsessDataResult<List<EducationListDTO>>(educationlistDto, "Education Listeleme Başarılı");

        }

        public async Task<IDataResult<EducationDTO>> GetByIdAsync(Guid id)
        {
            var education = await _educationRepository.GetByIdAsync(id);

            if (education is null)
            {
                return new ErorDataResult<EducationDTO>(education.Adapt<EducationDTO>(), "Education Bulunamadı");
            }

            return new SuccsessDataResult<EducationDTO>(education.Adapt<EducationDTO>(), "Education Bulundu");
        }

        public async Task<IResult> UpdateAsync(EducationUpdateDTO educationUpdateDTO)
        {
            var updatingEducation = await _educationRepository.GetByIdAsync(educationUpdateDTO.Id);

            if (updatingEducation is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedEducation = educationUpdateDTO.Adapt(updatingEducation);
                await _educationRepository.UpdateAsync(updatedEducation);
                await _educationRepository.SaveChangeAsync();
                return new SuccsesResult("Education Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }
    }
}
