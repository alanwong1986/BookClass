using System;
using System.Collections.Generic;

namespace BookClassSimple.Models
{
    public partial class Providers
    {
        public Providers()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifty { get; set; }
        public byte[] RecordTs { get; set; }

    }
}
