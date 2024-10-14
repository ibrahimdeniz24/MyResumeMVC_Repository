using Mapster;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.SocialMediaDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.SocialMediaRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.SocialMediaServices
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaService(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<IResult> AddAsync(SocialMediaCreateDTO socialMediaCreateDTO)
        {
            var newSocialMedia = socialMediaCreateDTO.Adapt<SocialMedia>();

            await _socialMediaRepository.AddAsync(newSocialMedia);
            await _socialMediaRepository.SaveChangeAsync();
            return new SuccsesResult("SocialMedia Ekleme Başarılı");

        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingSocialMedia = await _socialMediaRepository.GetByIdAsync(id);

            if (deletingSocialMedia == null) { return new ErorResult("Silinecek SocialMedia Bulunamadı"); }
            try
            {
                await _socialMediaRepository.DeleteAsync(deletingSocialMedia);
                await _socialMediaRepository.SaveChangeAsync();
                return new SuccsesResult("SocialMedia Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<SocialMediaListDTO>>> GetAllAsync()
        {
            var socialMedias = await _socialMediaRepository.GetAllAsync(x => x.CreatedDate, false);

            var socialMedialistDto = socialMedias.Adapt<List<SocialMediaListDTO>>();
            if (socialMedias.Count() <= 0)
            {
                return new ErorDataResult<List<SocialMediaListDTO>>(socialMedialistDto, "SocialMedia Listeleme Başarısız");
            }

            return new SuccsessDataResult<List<SocialMediaListDTO>>(socialMedialistDto, "SocialMedia Listeleme Başarılı");
        }

        public async Task<IDataResult<SocialMediaDTO>> GetByIdAsync(Guid id)
        {
            var socialMedia = await _socialMediaRepository.GetByIdAsync(id);

            if (socialMedia is null)
            {
                return new ErorDataResult<SocialMediaDTO>(socialMedia.Adapt<SocialMediaDTO>(), "SocialMedia Bulunamadı");
            }

            return new SuccsessDataResult<SocialMediaDTO>(socialMedia.Adapt<SocialMediaDTO>(), "SocialMedia Bulundu");
        }

        public async Task<IResult> UpdateAsync(SocialMediaUpdateDTO socialMediaUpdateDTO)
        {
            var updatingSocialMedia = await _socialMediaRepository.GetByIdAsync(socialMediaUpdateDTO.Id);

            if (updatingSocialMedia is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedSocialMedia = socialMediaUpdateDTO.Adapt(updatingSocialMedia);
                await _socialMediaRepository.UpdateAsync(updatedSocialMedia);
                await _socialMediaRepository.SaveChangeAsync();
                return new SuccsesResult("SocialMedia Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }
    }
}
