using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClassSimple.Models
{
    public partial class Images
    {
        public Images()
        {
            Courses = new HashSet<Courses>();
        }

        public int Id { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifty { get; set; }
        public byte[] RecordTs { get; set; }

        public ICollection<Courses> Courses { get; set; }

        [NotMapped]
        public IFormFile imageFile { get; set; }
    }
}
