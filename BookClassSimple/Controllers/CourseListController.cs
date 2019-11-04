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
    public class CourseListController : Controller
    {
        private readonly ICourseRepository courseRepository;

        public CourseListController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            CourseListViewModel courseListViewModel = new CourseListViewModel();

            courseListViewModel.Categorys = courseRepository.ListCategorys();
            courseListViewModel.Courses = courseRepository.ListCourses();
            return View(courseListViewModel);
        }
    }
}
