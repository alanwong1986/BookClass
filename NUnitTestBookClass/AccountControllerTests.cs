using BookClassSimple.Controllers;
using BookClassSimple.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using NUnitTestBookClass;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class AccountControllerTests
    {
        private AccountController accountController;

        [SetUp]
        public void Setup()
        {
            accountController = new AccountController(new FakeUserManager(), new FakeSignInManager());
        }

        [Test]
        public void Account_Register_Expected_Partial()
        {
            var result = (PartialViewResult)accountController.Register();
            Assert.AreEqual("_Register", result.ViewName);
        }

        [Test]
        public async Task Account_User_Register_Expected_Json()
        {
            var result = (JsonResult)await accountController.UserRegister(new AccountRegisterViewModel()
            {
                ConfirmPassword = "1",
                Password = "1",
                Email = "test@gmail.com",
                PhoneNumber = "1"
            });
            Assert.AreEqual("/Home/Index", ((AjaxRedirectResult)result.Value).href);
        }

        [Test]
        public void Account_Login_Expected_Partial()
        {
            var result = (PartialViewResult)accountController.Login();
            Assert.AreEqual("_Login", result.ViewName);
        }

        [Test]
        public async Task Account_User_Login_Expected_Json()
        {
            var result = (JsonResult)await accountController.UserLogin(new AccountLoginViewModel()
            {
                Password = "1",
                Email = "test@gmail.com",
            });
            Assert.AreEqual("/Home/Index", ((AjaxRedirectResult)result.Value).href);
        }

        [Test]
        public async Task Account_User_Logout_Expected_Redirect()
        {
            var result = (RedirectToActionResult)await accountController.UserLogout();
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }
    }
}