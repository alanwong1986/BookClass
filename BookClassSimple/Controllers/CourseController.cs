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
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly ICourseCommentRepository courseCommentRepository;
        private readonly UserManager<IdentityUser> userManager;

        public CourseController(ICourseRepository courseRepository, ICourseCommentRepository courseCommentRepository, UserManager<IdentityUser>  userManager)
        {
            this.userManager = userManager;
            this.courseRepository = courseRepository;
            this.courseCommentRepository = courseCommentRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(int id)
        {
            CourseViewModel courseViewModel = new CourseViewModel();

            courseViewModel.Course = courseRepository.GetCoursesById(id);
            if (courseViewModel.Course != null)
            {
                courseViewModel.CourseDate = courseViewModel.Course.CourseDate.Select(d => new CourseDateViewModel()
                {
                    CourseDate = d.Date,
                    CourseDateId = d.Id,
                    CourseTimes = d.CourseTime.Select(t => new CourseTimeViewModel()
                    {
                        CourseTime = t.Time,
                        CourseTimeId = t.Id
                    })
                });
            }
            courseViewModel.CourseComments = new CourseCommentViewModel() {
                CourseId = id,
                CourseComments = courseCommentRepository.ListCommentsByCourse(id)
            };
            return View(courseViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BookCourse(int courseTimeId)
        {
            if (HttpContext != null)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                await courseRepository.AddUserRegister(new UserRegister()
                {
                    CourseTimeId = courseTimeId,
                    UserId = user.Id
                });
            }

            return Content("Class Booked Successfully");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListBooking()
        {
            ListBookingViewModel model = new ListBookingViewModel();
            if (HttpContext != null)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                model.UserRegister = courseRepository.ListBooking(user.Id);
            }
            return View(model);
        }
    }
}
