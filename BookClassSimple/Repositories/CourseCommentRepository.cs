using BookClassSimple.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClassSimple.Repositories
{
    public class CourseCommentRepository : ICourseCommentRepository
    {
        private readonly ILogger logger;

        private bookclassContext context = null;
        public CourseCommentRepository(bookclassContext context, ILogger<CourseCommentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<UserComments> ListCommentsByCourse(int courseId)
        {
            return context.UserComments.Where(uc => uc.CourseId == courseId).OrderByDescending(c => c.CreateDate);
        }

        public async Task AddUserComment(UserComments userComments)
        {
            try
            {
                context.UserComments.Add(userComments);
                await context.SaveChangesAsync();
            } catch (Exception e) {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task UpdateUserComment(UserComments userComments)
        {
            try
            {
                context.UserComments.Update(userComments);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        public async Task DeleteUserComment(int id)
        {
            try
            {
                UserComments uc = context.UserComments.FirstOrDefault(c => c.Id == id);
                context.UserComments.Remove(uc); 
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
