using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookClassSimple.Models
{
    public partial class UserComments
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? UserRateing { get; set; }
        [Required(ErrorMessage = "Comment is required"), MaxLength(2000, ErrorMessage = "Comment is too long")]
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifty { get; set; }
        public byte[] RecordTs { get; set; }
        public int CourseId { get; set; }

        public Courses Courses { get; set; }
    }
}
