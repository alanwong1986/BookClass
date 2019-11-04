using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookClassSimple.Models
{
    public partial class Courses
    {
        public Courses()
        {
            CourseDate = new HashSet<CourseDate>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Image")]
        public int ImageId { get; set; }
        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifty { get; set; }
        public byte[] RecordTs { get; set; }
        [Required]
        public decimal Price { get; set; }

        public Categorys Category { get; set; }
        public Images Image { get; set; }
        public Location Location { get; set; }
        public ICollection<CourseDate> CourseDate { get; set; }
        public ICollection<UserComments> UserComments { get; set; }
    }
}
