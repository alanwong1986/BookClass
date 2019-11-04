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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class AdminControllerTests
    {
        private AdminController adminController;

        [SetUp]
        public void Setup()
        {

            adminController = new AdminController(new FakeCourseRepository());
        }

        #region "Category"
        [Test]
        public void ManageCategories_Expected_View()
        {
            var result = adminController.ManageCategories();
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void RefreshCategoryList_Expected_Partial()
        {
            var result = adminController.RefreshCategoryList();
            Assert.AreEqual("_CategoriesList", ((PartialViewResult)result).ViewName);
        }

        [Test]
        public void CategoryEditor_Expected_Partial()
        {
            var result = adminController.CategoryEditor(null);
            Assert.AreEqual("_CategoriesEditor", ((PartialViewResult)result).ViewName);
        }

        [Test]
        public void AddEditCategory_Expected_Json()
        {
            var result = adminController.AddEditCategory(new Categorys()
            {
                Icon = "test",
                Name = "test"
            });
            var json = ((JsonResult)(result.Result)).Value;
            System.Reflection.PropertyInfo pi = json.GetType().GetProperty("success");
            String success = (String)(pi.GetValue(json, null));

            Assert.AreEqual("true", success);
        }

        [Test]
        public void DeleteCategory_Expected_Json()
        {
            var result = adminController.DeleteCategory(0);
            var json = ((JsonResult)(result.Result)).Value;
            System.Reflection.PropertyInfo pi = json.GetType().GetProperty("success");
            String success = (String)(pi.GetValue(json, null));

            Assert.AreEqual("true", success);
        }
        #endregion

        #region "Course"
        [Test]
        public void ManageCourses_Expected_View()
        {
            var result = adminController.ManageCourses();
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void RefreshCourseList_Expected_Partial()
        {
            var result = adminController.RefreshCourseList();
            Assert.AreEqual("_CoursesList", ((PartialViewResult)result).ViewName);
        }

        [Test]
        public void CoursesEditor_Expected_Partial()
        {
            var result = adminController.CoursesEditor(null);
            Assert.AreEqual("_CoursesEditor", ((PartialViewResult)result).ViewName);
        }

        [Test]
        public void AddEditCourse_Expected_Json()
        {
            var result = adminController.AddEditCourse(new Courses()
            {
                CategoryId = 0,
                ImageId = 0,
                Description = "test",
                LocationId = 0,
                Name = "test",
                Price = 0
            });
            var json = ((JsonResult)(result.Result)).Value;
            System.Reflection.PropertyInfo pi = json.GetType().GetProperty("success");
            String success = (String)(pi.GetValue(json, null));

            Assert.AreEqual("true", success);
        }

        [Test]
        public void DeleteCourse_Expected_Json()
        {
            var result = adminController.DeleteCourse(0);
            var json = ((JsonResult)(result.Result)).Value;
            System.Reflection.PropertyInfo pi = json.GetType().GetProperty("success");
            String success = (String)(pi.GetValue(json, null));

            Assert.AreEqual("true", success);
        }

        #endregion

        #region "Location"
        [Test]
        public void ManageLocation_Expected_View()
        {
            var result = adminController.ManageLocation();
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void RefreshLocationList_Expected_Partial()
        {
            var result = adminController.RefreshLocationList();
            Assert.AreEqual("_LocationList", ((PartialViewResult)result).ViewName);
        }

        [Test]
        public void LocationEditor_Expected_Partial()
        {
            var result = adminController.LocationEditor(null);
            Assert.AreEqual("_LocationEditor", ((PartialViewResult)result).ViewName);
        }

        [Test]
        public void AddEditLocation_Expected_Json()
        {
            var result = adminController.AddEditLocation(new Location()
            {
                Lng = 0,
                Lat = 0,
                Address = "test"
            });
            var json = ((JsonResult)(result.Result)).Value;
            System.Reflection.PropertyInfo pi = json.GetType().GetProperty("success");
            String success = (String)(pi.GetValue(json, null));

            Assert.AreEqual("true", success);
        }

        [Test]
        public void DeleteLocation_Expected_Json()
        {
            var result = adminController.DeleteLocation(0);
            var json = ((JsonResult)(result.Result)).Value;
            System.Reflection.PropertyInfo pi = json.GetType().GetProperty("success");
            String success = (String)(pi.GetValue(json, null));

            Assert.AreEqual("true", success);
        }
        #endregion

        #region "Image"
        [Test]
        public void ManageImages_Expected_View()
        {
            var result = adminController.ManageImages();
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void RefreshImageList_Expected_Partial()
        {
            var result = adminController.RefreshImageList();
            Assert.AreEqual("_ImageList", ((PartialViewResult)result).ViewName);
        }

        [Test]
        public void ImageEditor_Expected_Partial()
        {
            var result = adminController.ImageEditor(null);
            Assert.AreEqual("_ImageEditor", ((PartialViewResult)result).ViewName);
        }

        [Test]
        public void AddImage_Expected_Json()
        {
            var result = adminController.AddImage(new Images()
            {
                Description = "test",
                Path = "test",
                imageFile = null
            });
            var json = ((JsonResult)(result.Result)).Value;
            System.Reflection.PropertyInfo pi = json.GetType().GetProperty("success");
            String success = (String)(pi.GetValue(json, null));

            Assert.AreEqual("true", success);
        }

        [Test]
        public void DeleteImage_Expected_Json()
        {
            var result = adminController.DeleteImage(0);
            var json = ((JsonResult)(result.Result)).Value;
            System.Reflection.PropertyInfo pi = json.GetType().GetProperty("success");
            String success = (String)(pi.GetValue(json, null));

            Assert.AreEqual("true", success);
        }
        #endregion

        #region "Schedule"
        public void CoursesScheduleEditor_Expected_Partial()
        {
            var result = adminController.CoursesScheduleEditor(0);
            Assert.AreEqual("_CoursesScheduleEditor", ((PartialViewResult)result).ViewName);
        }
        public void SaveCourseSchedule_Expected_Json()
        {
            var result = adminController.SaveCourseSchedule(new CourseScheduleViewModel()
            {
                 CourseId = 0,
                 CourseDate = new List<CourseDateViewModel>()
            });

            var json = ((JsonResult)(result.Result)).Value;
            System.Reflection.PropertyInfo pi = json.GetType().GetProperty("success");
            String success = (String)(pi.GetValue(json, null));

            Assert.AreEqual("true", success);
        }
        #endregion
    }
}