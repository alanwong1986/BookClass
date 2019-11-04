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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookClassSimple.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ICourseRepository courseRepository;
        public AdminController(ICourseRepository courseRepository)
        { 
            this.courseRepository = courseRepository;
        }

        #region "Category"
        [HttpGet]
        public IActionResult ManageCategories()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RefreshCategoryList()
        {
            ManageCategoryViewModel model = new ManageCategoryViewModel()
            {
                Categorys = courseRepository.ListCategorys()
            };

            return PartialView("_CategoriesList", model);
        }

        [HttpGet]
        public IActionResult CategoryEditor(int? id)
        {
            Categorys model;
            if (id == null)
            {
                model = new Categorys();
            } else
            {
                model = courseRepository.GetCategoryById(id.Value);
            }

            return PartialView("_CategoriesEditor", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditCategory(Categorys model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    await courseRepository.AddCategory(model);
                }
                else
                {
                    await courseRepository.UpdateCategory(model);
                }
                return Json(new { success = "true" });
            } else
            {
                return PartialView("_CategoriesEditor", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (courseRepository.IsCourseExistedByCategoryId(id))
            {
                return Json(new { success = "false", message="There are courses under this category." });
            }
            await courseRepository.DeleteCategory(id);
            return Json(new { success = "true"});
        }
        #endregion

        #region "Course"
        [HttpGet]
        public IActionResult ManageCourses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RefreshCourseList()
        {
            ManageCourseViewModel model = new ManageCourseViewModel()
            {
                Courses = courseRepository.ListCourses()
            };

            return PartialView("_CoursesList", model);
        }

        [HttpGet]
        public IActionResult CoursesEditor(int? id)
        {
            Courses model;
            if (id == null)
            {
                model = new Courses();
            }
            else
            {
                model = courseRepository.GetCoursesById(id.Value);
            }

            ViewData["CategoryList"] = courseRepository.ListCategorys().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            ViewData["LocationList"] = courseRepository.ListLocations().Select(c => new SelectListItem()
            {
                Text = c.Address,
                Value = c.Id.ToString()
            }).ToList();

            ViewData["ImageList"] = courseRepository.ListImages().ToList();

            return PartialView("_CoursesEditor", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditCourse(Courses model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    await courseRepository.AddCourse(model);
                }
                else
                {
                    await courseRepository.UpdateCourse(model);
                }
                return Json(new { success = "true" });
            }
            else
            {
                return PartialView("_CoursesEditor", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (courseRepository.IsRecordsExistedByCourseId(id))
            {
                return Json(new { success = "false", message = "There are schedule assigned to this course." });
            }
            await courseRepository.DeleteCourse(id);
            return Json(new { success = "true" });
        }
        #endregion

        #region "Location"
        [HttpGet]
        public IActionResult ManageLocation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RefreshLocationList()
        {
            ManageLocationViewModel model = new ManageLocationViewModel()
            {
                Location = courseRepository.ListLocations()
            };

            return PartialView("_LocationList", model);
        }

        [HttpGet]
        public IActionResult LocationEditor(int? id)
        {
            Location model;
            if (id == null)
            {
                model = new Location();
            }
            else
            {
                model = courseRepository.GetLocationById(id.Value);
            }

            return PartialView("_LocationEditor", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditLocation(Location model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    await courseRepository.AddLocation(model);
                }
                else
                {
                    await courseRepository.UpdateLocation(model);
                }
                return Json(new { success = "true" });
            }
            else
            {
                return PartialView("_LocationEditor", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (courseRepository.IsCourseExistedByLocationId(id))
            {
                return Json(new { success = "false", message = "There are courses using this Location." });
            }
            await courseRepository.DeleteLocation(id);
            return Json(new { success = "true" });
        }


        #endregion

        #region "Image"
        [HttpGet]
        public IActionResult ManageImages()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RefreshImageList()
        {
            ManageImageViewModel model = new ManageImageViewModel()
            {
                Image = courseRepository.ListImages()
            };

            return PartialView("_ImageList", model);
        }

        [HttpGet]
        public IActionResult ImageEditor(int? id)
        {
            Images model;
            if (id == null)
            {
                model = new Images();
            }
            else
            {
                model = courseRepository.GetImageById(id.Value);
            }

            return PartialView("_ImageEditor", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage(Images model)
        {
            if (ModelState.IsValid)
            {

                await courseRepository.AddImage(model);
                return Json(new { success = "true" });
            }
            else
            {
                return PartialView("_ImageEditor", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(int id)
        {
            if (courseRepository.IsCourseExistedByImageId(id))
            {
                return Json(new { success = "false", message = "There are courses using this image." });
            }
            await courseRepository.DeleteImage(id);
            return Json(new { success = "true" });
        }

        #endregion

        #region "Course Schedule"
        [HttpGet]
        public IActionResult CoursesScheduleEditor(int id)
        {
            var model = new CourseScheduleViewModel()
            {
                CourseId = id,
                CourseDate = courseRepository.GetCoursesById(id).CourseDate.Select(c => new CourseDateViewModel()
                {
                    CourseDate = c.Date,
                    CourseDateId = c.Id,
                    CourseTimes = c.CourseTime.Select(t => new CourseTimeViewModel()
                    {
                        CourseTimeId = t.Id,
                        CourseTime = t.Time
                    })
                })
            };
            
            return PartialView("_CoursesScheduleEditor", model);
        }
        
        [HttpPost]
        public async Task<IActionResult> SaveCourseSchedule(CourseScheduleViewModel vm)
        {
            var deletedTime = vm.CourseDate.SelectMany(c => c.CourseTimes.Where(d => d.Action == "del").Select(d => d.CourseTimeId)).ToList();
            if (courseRepository.IsRegisterExistedByCourseTimeId(deletedTime))
            {
                return Json(new { success = "false", message = "There are bookings under some of the deleted time" });
            }

            await courseRepository.SaveCourseSchedule(vm);
            return Json(new { success = "true" });
        }
        #endregion
    }
}
