using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyResume.Domain.Enums;
using MyResume.Domain.Utilities.Concretes;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression)
        {
            try
            {
                return await _userManager.Users.AnyAsync(expression);
            }
            catch (Exception ex)
            {

                throw new Exception("Error checking if any users match the expression", ex);
            }
        }

        public async Task<IdentityResult> CreateUserAsync(IdentityUser user, string password, Roles role)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    return result;
                }

                return await _userManager.AddToRoleAsync(user, role.ToString());

            }
            catch (Exception ex)
            {

                throw new Exception("Error creating user", ex);
            }
        }

        public async Task<IdentityResult> DeleteAsync(IdentityUser user)
        {
            try
            {
                return await _userManager.DeleteAsync(user);
            }
            catch (Exception ex)
            {

                throw new Exception("Silinecek User Bulunuanamadı",ex);
            }
        }

        public async Task<IDataResult<IdentityUser>> FindByEmailAsync(string email)
        {
            try
            {
                var result = await _userManager.FindByEmailAsync(email);

                if (result is null)
                {
                    return new ErorDataResult<IdentityUser>(result, "Email bulma başarısız");
                }

                return new SuccsessDataResult<IdentityUser>(result, "Email bulma başarılı");
            }
            catch (Exception ex)
            {

                throw new Exception("Email bulma başarısız", ex);
            }
        }

        public async Task<IDataResult<IdentityUser>> FindByIdAsync(string IdentityId)
        {
            try
            {
                var result = await _userManager.FindByIdAsync(IdentityId);

                if (result is null)
                {
                    return new ErorDataResult<IdentityUser>(result, "Kullanıcı Bulma Başarısız");
                }

                return new SuccsessDataResult<IdentityUser>(result, "Kullanıcı Bulma Başarılı");
            }
            catch (Exception ex)
            {

                throw new Exception("Kullanıcı Bulma Başarısız", ex);
            }
        }

        public async Task<IDataResult<IList<string>>> GetRolesAsync(IdentityUser user)
        {
            var rolesList = await _userManager.GetRolesAsync(user);
            try
            {
                if (rolesList == null)
                {
                    return new ErorDataResult<IList<string>>(rolesList, "Kullanıcı bulunamadı");
                }
                return new SuccsessDataResult<IList<string>>(rolesList, "Kullanıcı başarıyla getirildi");

            }
            catch (Exception ex)
            {

                throw new Exception("Error getting the roles of the user", ex);
            }
        }

        public async Task<string> PasswordHasher(IdentityUser user, string password)
        {
            try
            {
                return await Task.Run(() => _userManager.PasswordHasher.HashPassword(user, password));
            }
            catch (Exception ex)
            {

                throw new Exception("Error hashing the password for user", ex);
            }
        }

        public async Task<SignInResult> PasswordSignInAsync(IdentityUser user, string password)
        {
            try
            {
                return await _signInManager.PasswordSignInAsync(user, password, false, false);
            }
            catch (Exception ex)
            {

                throw new Exception("Error signing in", ex);
            }
        }

        public async Task SignOutAsync()
        {
            try
            {
                 await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error signing out", ex);
            }
        }

        public async Task<IdentityResult> UpdateAsync(IdentityUser user)
        {
            try
            {
                return await _userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {

                throw new Exception("Error updating the user", ex);
            }
        }
    }
}
