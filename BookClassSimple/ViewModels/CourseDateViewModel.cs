using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookClassSimple.Models
{
    public class CourseDateViewModel
    {
        public DateTime CourseDate { get; set; }
        public int CourseDateId { get; set; }
        public IEnumerable<CourseTimeViewModel> CourseTimes { get; set; }
        public string Action { get; set; }
    }

    public class CourseTimeViewModel
    {
        public TimeSpan CourseTime { get; set; }
        public int CourseTimeId { get; set; }
        public string Action { get; set; }
    }
}
