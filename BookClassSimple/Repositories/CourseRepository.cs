using BookClassSimple.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookClassSimple.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ILogger logger;
        private readonly IHostingEnvironment hostingEnvironment;

        private bookclassContext context = null;
        public CourseRepository(bookclassContext context, ILogger<CourseRepository> logger, IHostingEnvironment hostingEnvironment)
        {
            this.context = context;
            this.logger = logger;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<Categorys> ListCategorys()
        {
            return context.Categorys;
        }

        public IEnumerable<Courses> ListCourses()
        {
            return context.Courses.Include(c => c.Category).Include(c => c.Image);
        }

        public IEnumerable<Location> ListLocations()
        {
            return context.Location;
        }
        public IEnumerable<Images> ListImages()
        {
            return context.Images;
        }

        public IEnumerable<UserRegister> ListBooking(string userId)
        {
            return context.UserRegister.Where(c => c.UserId == userId).Include(c => c.CourseTime)
                .ThenInclude(c => c.CourseDate)
                .ThenInclude(c => c.Course);
        }

        public Courses GetCoursesById(int courseId)
        {
            return context.Courses.Include(c => c.Image)
                .Include(c=>c.Location)
                .Include(c=>c.CourseDate)
                    .ThenInclude(d => d.CourseTime)
                .FirstOrDefault(c => c.Id == courseId);
        }

        public Categorys GetCategoryById(int catId)
        {
            return context.Categorys.FirstOrDefault(c => c.Id == catId);
        }

        public Boolean IsCourseExistedByCategoryId (int catId)
        {
            return context.Courses.Any(c => c.CategoryId == catId);
        }

        public Boolean IsCourseExistedByLocationId(int locId)
        {
            return context.Courses.Any(c => c.LocationId == locId);
        }

        public Boolean IsCourseExistedByImageId(int imgId)
        {
            return context.Courses.Any(c => c.ImageId == imgId);
        }

        public Boolean IsRecordsExistedByCourseId(int courseId)
        {
            return context.UserComments.Any(c => c.CourseId == courseId) ||
                context.CourseDate.Any(c => c.CourseId == courseId);
        }

        public Boolean IsRegisterExistedByCourseTimeId(List<int> timeIds)
        {
            return context.UserRegister.Any(c => timeIds.Contains(c.CourseTimeId));
        }

        public async Task AddCategory(Categorys categorys)
        {
            try
            {
                context.Categorys.Add(categorys);
                await context.SaveChangesAsync();
            } catch (Exception e) {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task UpdateCategory(Categorys categorys)
        {
            try
            {
                categorys.LastModifty = DateTime.Now;
                context.Categorys.Update(categorys);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task DeleteCategory(int id)
        {
            try
            {
                Categorys cat = context.Categorys.FirstOrDefault(c => c.Id == id);
                context.Categorys.Remove(cat); 
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task AddCourse(Courses course)
        {
            try
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task UpdateCourse(Courses course)
        {
            try
            {
                context.Courses.Update(course);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task DeleteCourse(int id)
        {
            try
            {
                Courses course = context.Courses.FirstOrDefault(c => c.Id == id);
                context.Courses.Remove(course);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task AddUserRegister(UserRegister userRegister)
        {
            try
            {
                context.UserRegister.Add(userRegister);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public Location GetLocationById(int locId)
        {
            return context.Location.FirstOrDefault(c => c.Id == locId);
        }

        public async Task AddLocation(Location location)
        {
            try
            {
                context.Location.Add(location);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task UpdateLocation(Location location)
        {
            try
            {
                context.Location.Update(location);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task DeleteLocation(int id)
        {
            try
            {
                Location location = context.Location.FirstOrDefault(c => c.Id == id);
                context.Location.Remove(location);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public Images GetImageById(int imgId)
        {
            return context.Images.FirstOrDefault(c => c.Id == imgId);
        }

        public async Task AddImage(Images image)
        {
            try
            {
                if (image.imageFile != null)
                {
                    string ext = System.IO.Path.GetExtension(image.imageFile.FileName);
                    var lastImage = context.Images.OrderByDescending(c => c.Id).FirstOrDefault();
                    string lastId = "1";
                    if (lastImage != null)
                    {
                        lastId = (lastImage.Id + 1).ToString();
                    }
                    string storeFileName = "/Images/Courses/" + lastId + ext;

                    var filePath = hostingEnvironment.WebRootPath + storeFileName;

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await image.imageFile.CopyToAsync(stream);
                    }

                    image.Path = storeFileName;
                }
                context.Images.Add(image);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task DeleteImage(int id)
        {
            try
            {
                Images image = context.Images.FirstOrDefault(c => c.Id == id);
                if (image != null)
                {
                    string fullPath = hostingEnvironment.WebRootPath + image.Path;
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
                context.Images.Remove(image);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task SaveCourseSchedule(CourseScheduleViewModel vm)
        {
            try
            {
                var addedDate = vm.CourseDate.Where(c => c.Action == "add").Select(c => new CourseDate()
                {
                    CourseId = vm.CourseId,
                    Date = c.CourseDate,
                    CourseTime = c.CourseTimes.Select(d => new CourseTime()
                    {
                        Time = d.CourseTime
                    }).ToList()
                });

                context.CourseDate.AddRange(addedDate);

                var addedTime = vm.CourseDate.Where(c => c.Action == null).SelectMany(c => c.CourseTimes.Where(d => d.Action == "add").Select(d => 
                    new CourseTime()
                    {
                        CourseDateId = c.CourseDateId,
                        Time = d.CourseTime
                    })
                );
                context.CourseTime.AddRange(addedTime);

                var deletedDate = context.CourseDate.Where(c=> vm.CourseDate.Where(d => d.Action == "del").Select(e => e.CourseDateId).Contains(c.Id));
                var deletedTime = context.CourseTime.Where(c => vm.CourseDate.SelectMany(d => d.CourseTimes).Where(e => e.Action == "del").Select(e => e.CourseTimeId).Contains(c.Id));
                context.CourseTime.RemoveRange(deletedTime);
                context.CourseDate.RemoveRange(deletedDate);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }
    }
}
