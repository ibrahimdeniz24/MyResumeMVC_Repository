using Mapster;
using MyResume.Business.DTOs.AdminDTOs;
using MyResume.Business.Services.AccountServices;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.AdminRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAccountService _accountService;

        public AdminService(IAdminRepository adminRepository, IAccountService accountService)
        {
            _adminRepository = adminRepository;
            _accountService = accountService;
        }

        public async Task<IResult> AddAsync(AdminCreateDTO adminCreateDTO)
        {
            var newAdmin = adminCreateDTO.Adapt<Admin>();

            try
            {
                await _adminRepository.AddAsync(newAdmin);
                await _adminRepository.SaveChangeAsync();
                return new SuccsesResult("Admin Ekleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingAdmin = await _adminRepository.GetByIdAsync(id);

            if (deletingAdmin != null)
            {
                return new ErorResult("Silinecek Admin Bulunamadı");
            }

            var adminDTO = deletingAdmin.Adapt<Admin>();

            try
            {
                await _adminRepository.DeleteAsync(adminDTO);
                await _adminRepository.SaveChangeAsync();
                return new SuccsesResult("Admin Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }

        public async Task<IDataResult<List<AdminListDTO>>> GetAllAsync()
        {
            
                throw new NotImplementedException();
        }

        public async Task<IDataResult<AdminDTO>> GetByIdAsync(Guid id)
        {
            var admin = await _adminRepository.GetByIdAsync(id);
            try
            {
                if (admin is null)
                {
                    return new ErorDataResult<AdminDTO>(admin.Adapt<AdminDTO>(),"Admin Bulunumadı");
                }

                return new SuccsessDataResult<AdminDTO>(admin.Adapt<AdminDTO>(), "Admin Bulma Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorDataResult<AdminDTO>(admin.Adapt<AdminDTO>(), "Admin Bulunumadı" + ex.Message);
            }
        }

        public Task<IResult> UpdateAsync(AdminUpdateDTO adminUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
