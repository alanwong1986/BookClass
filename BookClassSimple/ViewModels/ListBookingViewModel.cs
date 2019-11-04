using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookClassSimple.Models
{
    public class ListBookingViewModel
    {
        public IEnumerable<UserRegister> UserRegister { get; set; }
    }
}
