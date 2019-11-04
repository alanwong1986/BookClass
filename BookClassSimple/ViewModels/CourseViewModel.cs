using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookClassSimple.Models
{
    public class CourseViewModel
    {
        public Courses Course { get; set; }
        public IEnumerable<CourseDateViewModel> CourseDate { get; set; }

        public CourseCommentViewModel CourseComments { get; set; }
    }
}
