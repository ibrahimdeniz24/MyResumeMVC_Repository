using Mapster;
using MyResume.Business.DTOs.ContactDTOs;
using MyResume.Business.DTOs.FeatureDTOs;
using MyResume.Domain.Entities;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using MyResume.Infrastructure.Repositories.ContactRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepositories _contactRepositories;

        public ContactService(IContactRepositories contactRepositories)
        {
            _contactRepositories = contactRepositories;
        }

        public async Task<IResult> AddAsync(ContactCreateDTO contactCreateDTO)
        {
            
            var newContact = contactCreateDTO.Adapt<Contact>();

            await _contactRepositories.AddAsync(newContact);
            await _contactRepositories.SaveChangeAsync();
            return new SuccsesResult("Contact Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingContact = await _contactRepositories.GetByIdAsync(id);

            if (deletingContact == null)
            {
                return new ErorResult("Silinecek Contact Bulunamadı");
            }

            try
            {
                await _contactRepositories.DeleteAsync(deletingContact);
                await _contactRepositories.SaveChangeAsync();
                return new SuccsesResult("Contact Silme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }

        }

        public async Task<IDataResult<List<ContactListDTO>>> GetAllAsync()
        {
            var contacts = await _contactRepositories.GetAllAsync(x => x.CreatedDate, false);
            var contactList = contacts.Adapt<List<ContactListDTO>>();
            if (contacts.Count() <= 0)
            {
                return new ErorDataResult<List<ContactListDTO>>(contactList, "Contaxt Listeleme Başarısız");
            }
            return new SuccsessDataResult<List<ContactListDTO>>(contactList, "Contaxt Listeleme Başarılı");


        }

        public async Task<IDataResult<ContactDTO>> GetByIdAsync(Guid id)
        {
            var contact = await _contactRepositories.GetByIdAsync(id);
            var contactDTO = contact.Adapt<ContactDTO>();
            if (contact is null)
            {
                return new ErorDataResult<ContactDTO>(contactDTO, "Contaxt Bulma Başarısız");
            }

            return new SuccsessDataResult<ContactDTO>(contactDTO, "Contaxt Bulma Başarılı");
        }

        public async Task<IResult> UpdateAsync(ContactUpdateDTO contactUpdateDTO)
        {
            var updatingContact = await _contactRepositories.GetByIdAsync(contactUpdateDTO.Id);

            if (updatingContact is null)
            {
                return new ErorResult("Güncellenecek veri Bulunuamadı");
            }

            try
            {
                var updatedFeature = contactUpdateDTO.Adapt(updatingContact);
                await _contactRepositories.UpdateAsync(updatedFeature);
                await _contactRepositories.SaveChangeAsync();
                return new SuccsesResult("Contact Güncelleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErorResult("Hata : " + ex.Message);
            }
        }
    }
}
