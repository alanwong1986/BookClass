using BookClassSimple.Controllers;
using BookClassSimple.Models;
using BookClassSimple.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public class HomeControllerTests
    {
        private HomeController homeController;

        [SetUp]
        public void Setup()
        {
            homeController = new HomeController();
        }

        [Test]
        public void Index_Expected_View()
        {
            var result = homeController.Index();
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void Error_Expected_View()
        {
            var result = homeController.Error();
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }
    }
}