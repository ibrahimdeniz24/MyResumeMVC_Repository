using Microsoft.AspNetCore.Identity;
using MyResume.Domain.Enums;
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Business.Services.AccountServices
{
    public interface IAccountService
    {
        Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression);

        Task<IdentityResult> CreateUserAsync(IdentityUser user, string password, Roles role);

        Task<IDataResult<IdentityUser>> FindByIdAsync(string IdentityId);

        Task<IDataResult<IdentityUser>> FindByEmailAsync(string email);

        Task<IDataResult<IList<string>>> GetRolesAsync(IdentityUser user);

        Task<SignInResult> PasswordSignInAsync(IdentityUser user, string password);

        Task SignOutAsync();

        Task<IdentityResult> DeleteAsync(IdentityUser user);

        Task<IdentityResult> UpdateAsync(IdentityUser user);

        Task<string> PasswordHasher(IdentityUser user, string password);
    }
}
