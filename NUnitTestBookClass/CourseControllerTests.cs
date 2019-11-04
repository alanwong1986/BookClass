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
    public class CourseControllerTests
    {
        private CourseController courseController;

        [SetUp]
        public void Setup()
        {

            courseController = new CourseController(new FakeCourseRepository(), new FakeCourseCommentRepository(), new FakeUserManager());
        }

        [Test]
        public void Index_Expected_View()
        {
            var result = courseController.Index(1);
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void BookCourse_Expected_String()
        {
            var result = courseController.BookCourse(1);
            Assert.AreEqual("Class Booked Successfully", ((ContentResult)(result.Result)).Content);
        }

        [Test]
        public void ListBooking_Expected_View()
        {
            var result = courseController.ListBooking();
            Assert.IsInstanceOf(typeof(ViewResult), result.Result);
        }
    }
}