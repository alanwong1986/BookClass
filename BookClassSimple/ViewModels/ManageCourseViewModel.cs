using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookClassSimple.Models
{
    public class ManageCourseViewModel
    {
        public IEnumerable<Courses> Courses { get; set; }
    }
}
