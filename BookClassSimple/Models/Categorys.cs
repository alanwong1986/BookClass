using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookClassSimple.Models
{
    public partial class Categorys
    {
        public Categorys()
        {
            Courses = new HashSet<Courses>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Icon { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifty { get; set; }
        public byte[] RecordTs { get; set; }

        public ICollection<Courses> Courses { get; set; }
    }
}
