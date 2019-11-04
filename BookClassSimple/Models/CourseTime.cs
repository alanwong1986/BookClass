using System;
using System.Collections.Generic;

namespace BookClassSimple.Models
{
    public partial class CourseTime
    {
        public CourseTime()
        {
            UserRegister = new HashSet<UserRegister>();
        }

        public int Id { get; set; }
        public int CourseDateId { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifty { get; set; }
        public byte[] RecordTs { get; set; }

        public CourseDate CourseDate { get; set; }
        public ICollection<UserRegister> UserRegister { get; set; }
    }
}
