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
    public class CourseListControllerTests
    {
        private CourseListController courseListController;

        [SetUp]
        public void Setup()
        {
            courseListController = new CourseListController(new FakeCourseRepository());
        }

        [Test]
        public void Index_Expected_View()
        {
            var result = courseListController.Index();
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }
    }
}