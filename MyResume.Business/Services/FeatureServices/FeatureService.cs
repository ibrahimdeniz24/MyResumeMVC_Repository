using Mapster;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.FeatureRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.FeatureServices
{

    
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<IResult> AddAsync(FeatureCreateDTO featureCreateDTO)
        {
            var newFeature = featureCreateDTO.Adapt<Feature>();

            await _featureRepository.AddAsync(newFeature);
            await _featureRepository.SaveChangeAsync();
            return new SuccsesResult("Feature Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingFeature = await _featureRepository.GetByIdAsync(id);

            if (deletingFeature == null) { return new ErorResult("Silinecek Feature Bulunamadı"); }
            try
            {
                await _featureRepository.DeleteAsync(deletingFeature);
                await _featureRepository.SaveChangeAsync();
                return new SuccsesResult("Feature Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<FeatureListDTO>>> GetAllAsync()
        {
            var features = await _featureRepository.GetAllAsync(x=>x.CreatedDate,false);

            var featurelistDto = features.Adapt<List<FeatureListDTO>>();
            if (features.Count() <= 0)
            { 
                return new ErorDataResult<List<FeatureListDTO>>(featurelistDto,"Feature Listeleme Başarısız");
            }

            return new SuccsessDataResult<List<FeatureListDTO>>(featurelistDto, "Feature Listeleme Başarılı");


        }

        public async Task<IDataResult<FeatureDTO>> GetByIdAsync(Guid id)
        {
            var feature = await _featureRepository.GetByIdAsync(id);

            if (feature is null)
            {
                return new ErorDataResult<FeatureDTO>(feature.Adapt<FeatureDTO>(), "Feature Bulunamadı");
            }

            return new SuccsessDataResult<FeatureDTO>(feature.Adapt<FeatureDTO>(), "Feature Bulundu");
        }

        public async Task<IResult> UpdateAsync(FeatureUpdateDTO featureUpdateDTO)
        {
            var updatingFeature = await _featureRepository.GetByIdAsync(featureUpdateDTO.Id);

            if (updatingFeature is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedFeature = featureUpdateDTO.Adapt(updatingFeature);
                await _featureRepository.UpdateAsync(updatedFeature);
                await _featureRepository.SaveChangeAsync();
                return new SuccsesResult("Feature Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }
    }
}
