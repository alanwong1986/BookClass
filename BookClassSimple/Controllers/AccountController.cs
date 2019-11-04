using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookClassSimple.Models;
using BookClassSimple.Repositories;
using Microsoft.AspNetCore.Authorization;
using BookClassSimple.Enum;
using Microsoft.AspNetCore.Identity;

namespace BookClassSimple.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return PartialView("_Register");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRegister(AccountRegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await userManager.CreateAsync(new IdentityUser()
                {
                    Email = vm.Email,
                    EmailConfirmed = true,
                    UserName = vm.Email,
                    PhoneNumber = vm.PhoneNumber
                }, vm.Password);

                if (result.Succeeded)
                {
                    return await UserLogin(new AccountLoginViewModel()
                    {
                        Password = vm.Password,
                        Email = vm.Email
                    });
                } else
                {
                    foreach (IdentityError e in result.Errors)
                    {
                        ModelState.AddModelError("Id", e.Description);
                    }
                }
            }

            return PartialView("_Register");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return PartialView("_Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin(AccountLoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByEmailAsync(vm.Email);

                if (user == null)
                {
                    ModelState.AddModelError("Email", "Login Failed");
                } else
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, vm.Password, false, false);
                    if (result.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(user);
                        if (roles.Contains("admin"))
                        {
                            return Json(new AjaxRedirectResult() { href = "/Admin/ManageCategories" });
                        } else
                        {
                            return Json(new AjaxRedirectResult() { href = "/Home/Index" });
                        }
                    }
                    ModelState.AddModelError("Email", "Login Failed");
                }
                return PartialView("_Login", vm);
            } else
            {
                return PartialView("_Login", vm);
            }
        }

        [Authorize]
        public async Task<IActionResult> UserLogout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
