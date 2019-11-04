using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClassSimple.Models;

namespace BookClassSimple.Repositories
{
    public interface ICourseCommentRepository
    {
        IEnumerable<UserComments> ListCommentsByCourse(int courseId);
        Task AddUserComment(UserComments userComments);
        Task UpdateUserComment(UserComments userComments);
        Task DeleteUserComment(int id);
    }
}
