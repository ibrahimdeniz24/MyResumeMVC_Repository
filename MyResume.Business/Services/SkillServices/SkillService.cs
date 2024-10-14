using Mapster;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Business.DTOs.SkillDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.SkillRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.SkillServices
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IResult> AddAsync(SkillCreateDTO skillCreateDTO)
        {
            var newSkill = skillCreateDTO.Adapt<Skill>();

            await _skillRepository.AddAsync(newSkill);
            await _skillRepository.SaveChangeAsync();
            return new SuccsesResult("Skill Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingSkill = await _skillRepository.GetByIdAsync(id);

            if (deletingSkill == null) { return new ErorResult("Silinecek Skill Bulunamadı"); }
            try
            {
                await _skillRepository.DeleteAsync(deletingSkill);
                await _skillRepository.SaveChangeAsync();
                return new SuccsesResult("Skill Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<SkillListDTO>>> GetAllAsync()
        {
            var skills = await _skillRepository.GetAllAsync(x => x.CreatedDate, false);

            var skilllistDto = skills.Adapt<List<SkillListDTO>>();
            if (skills.Count() <= 0)
            {
                return new ErorDataResult<List<SkillListDTO>>(skilllistDto, "Skill Listeleme Başarısız");
            }

            return new SuccsessDataResult<List<SkillListDTO>>(skilllistDto, "Skill Listeleme Başarılı");
        }

        public async Task<IDataResult<SkillDTO>> GetByIdAsync(Guid id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);

            if (skill is null)
            {
                return new ErorDataResult<SkillDTO>(skill.Adapt<SkillDTO>(), "Skill Bulunamadı");
            }

            return new SuccsessDataResult<SkillDTO>(skill.Adapt<SkillDTO>(), "Skill Bulundu");
        }

        public async Task<IResult> UpdateAsync(SkillUpdateDTO skillUpdateDTO)
        {
            var updatingSkill = await _skillRepository.GetByIdAsync(skillUpdateDTO.Id);

            if (updatingSkill is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedFeature = skillUpdateDTO.Adapt(updatingSkill);
                await _skillRepository.UpdateAsync(updatedFeature);
                await _skillRepository.SaveChangeAsync();
                return new SuccsesResult("Skill Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }
    }
}
