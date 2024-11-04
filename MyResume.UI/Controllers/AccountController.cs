using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MyResume.Business.Services.AccountServices;
using MyResume.UI.Models.ViewModels.AccountVM;

namespace MyResume.UI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAccountService _accountService;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var user = await _accountService.FindByEmailAsync(model.Email);
            if (user == null)
            {
                await Console.Out.WriteLineAsync("Login işlemi başarısız");
                return View(model);
            }

            var checkPassword = await _accountService.PasswordSignInAsync(user.Data, model.Password);

            if (!checkPassword.Succeeded)
            {
                await Console.Out.WriteLineAsync("Login işlemi başarısız");
                return View(model);
            }

            var userRole = await _accountService.GetRolesAsync(user.Data);
            if (userRole == null)
            {
                await Console.Out.WriteLineAsync("Login işlemi başarısız");
                return View(model);
            }

            return RedirectToAction("Index", "Home", new { Area = userRole.Data[0].ToString() });
        }


        public async Task<IActionResult> Logout()
        {

            await _accountService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
