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
    public class CommentControllerTests
    {
        private CommentController commentController;

        [SetUp]
        public void Setup()
        { 

            commentController = new CommentController(new FakeCourseCommentRepository(), new FakeUserManager());
        }

        [Test]
        public async Task AddComment_Expected_Partial()
        {
            var result = await commentController.AddComment(new UserComments());
            Assert.AreEqual("_Comments", ((PartialViewResult)result).ViewName);
        }
    }
}