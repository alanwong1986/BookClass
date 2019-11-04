using System;
using System.Collections.Generic;

namespace BookClassSimple.Models
{
    public partial class UserRegister
    {
        public UserRegister()
        {
            UserComments = new HashSet<UserComments>();
        }

        public int Id { get; set; }
        public int CourseTimeId { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifty { get; set; }
        public byte[] RecordTs { get; set; }

        public CourseTime CourseTime { get; set; }
        public ICollection<UserComments> UserComments { get; set; }
    }
}
