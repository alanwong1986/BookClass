using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClassSimple.Models;

namespace BookClassSimple.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Categorys> ListCategorys();
        IEnumerable<Location> ListLocations();
        IEnumerable<Images> ListImages();
        IEnumerable<Courses> ListCourses();
        Categorys GetCategoryById(int catId);
        Boolean IsCourseExistedByCategoryId(int catId);
        Boolean IsCourseExistedByLocationId(int locId);
        Boolean IsCourseExistedByImageId(int imgId);
        Boolean IsRecordsExistedByCourseId(int courseId);
        Boolean IsRegisterExistedByCourseTimeId(List<int> timeIds);
        Task AddCategory(Categorys categorys);
        Task UpdateCategory(Categorys categorys);
        Task DeleteCategory(int id);
        Courses GetCoursesById(int courseId);
        Task AddCourse(Courses course);
        Task UpdateCourse(Courses course);
        Task DeleteCourse(int id);

        Location GetLocationById(int locId);
        Task AddLocation(Location location);
        Task UpdateLocation(Location location);
        Task DeleteLocation(int id);
        Images GetImageById(int imgId);
        Task AddImage(Images image);
        Task DeleteImage(int id);
        Task AddUserRegister(UserRegister userRegister);
        Task SaveCourseSchedule(CourseScheduleViewModel vm);

        IEnumerable<UserRegister> ListBooking(string userId);
    }
}
