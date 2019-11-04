using System;
using System.Collections.Generic;

namespace BookClassSimple.Models
{
    public partial class CourseDate
    {
        public CourseDate()
        {
            CourseTime = new HashSet<CourseTime>();
        }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifty { get; set; }
        public byte[] RecordTs { get; set; }

        public Courses Course { get; set; }
        public ICollection<CourseTime> CourseTime { get; set; }
    }
}
