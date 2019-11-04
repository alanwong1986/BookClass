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
using Microsoft.AspNetCore.Http;

namespace BookClassSimple.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICourseCommentRepository courseCommentRepository;
        private readonly UserManager<IdentityUser> userManager;

        public CommentController(ICourseCommentRepository courseCommentRepository, UserManager<IdentityUser>  userManager)
        {
            this.userManager = userManager;
            this.courseCommentRepository = courseCommentRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(UserComments UserComments)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext != null)
                {
                    var user = await userManager.GetUserAsync(HttpContext.User);
                    UserComments.UserId = user.Id;
                }
                await courseCommentRepository.AddUserComment(UserComments);
                ModelState.Clear();
            }

            CourseCommentViewModel courseCommentViewModel = new CourseCommentViewModel()
            {
                CourseId = UserComments.CourseId,
                CourseComments = courseCommentRepository.ListCommentsByCourse(UserComments.CourseId)
            };

            return PartialView("_Comments", courseCommentViewModel);
        }
    }
}
