using Mapster;
using MyResume.Business.DTOs.AboutDTOs;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.AboutRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepositories _aboutRepositories;

        public AboutService(IAboutRepositories aboutRepositories)
        {
            _aboutRepositories = aboutRepositories;
        }

        public async Task<IResult> AddAsync(AboutCreateDTO aboutCreateDTO)
        {
            if (aboutCreateDTO is null)
            {
                return new ErorResult("Eklenecek veri Bulunamadı");
            }

            bool aboutExists = await _aboutRepositories.AnyAsync();

            if (aboutExists) 
            {
                return new ErorResult("Sistemde bir About kayıtlı");
            }

            var newAbout = aboutCreateDTO.Adapt<About>();

            await _aboutRepositories.AddAsync(newAbout);
            await _aboutRepositories.SaveChangeAsync();
            return new SuccsesResult("About Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingAbout = await _aboutRepositories.GetByIdAsync(id);

            if (deletingAbout == null) { return new ErorResult("Silinecek About Bulunamadı"); }
            try
            {
                await _aboutRepositories.DeleteAsync(deletingAbout);
                await _aboutRepositories.SaveChangeAsync();
                return new SuccsesResult("About Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<AboutListDTO>>> GetAllAsync()
        {
            var abouts = await _aboutRepositories.GetAllAsync(x => x.CreatedDate, false);

            var aboutlistDto = abouts.Adapt<List<AboutListDTO>>();
            if (abouts.Count() <= 0)
            {
                return new ErorDataResult<List<AboutListDTO>>(aboutlistDto, "About Listeleme Başarısız");
            }

            return new SuccsessDataResult<List<AboutListDTO>>(aboutlistDto, "About Listeleme Başarılı");
        }

        public async Task<IDataResult<AboutDTO>> GetByIdAsync(Guid id)
        {
            var abouts = await _aboutRepositories.GetByIdAsync(id);

            if(abouts is null)
            {
                return new ErorDataResult<AboutDTO>(abouts.Adapt<AboutDTO>(),"About Bulunamadı");
            }

            return new SuccsessDataResult<AboutDTO>(abouts.Adapt<AboutDTO>(), "About Bulundu");

        }

        public async Task<IResult> UpdateAsync(AboutUpdateDTO aboutUpdateDTO)
        {
            var updatingAbout = await _aboutRepositories.GetByIdAsync(aboutUpdateDTO.Id);

            if (updatingAbout is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedFeature = aboutUpdateDTO.Adapt(updatingAbout);
                await _aboutRepositories.UpdateAsync(updatedFeature);
                await _aboutRepositories.SaveChangeAsync();
                return new SuccsesResult("About Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }

        }
    }
}
