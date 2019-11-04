using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookClassSimple.Models
{
    public partial class Location
    {
        public Location()
        {
            Courses = new HashSet<Courses>();
        }

        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal Lng { get; set; }
        [Required]
        public decimal Lat { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifty { get; set; }
        public byte[] RecordTs { get; set; }

        public ICollection<Courses> Courses { get; set; }
    }
}
