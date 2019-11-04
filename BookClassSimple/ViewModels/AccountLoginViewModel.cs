using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookClassSimple.Models
{
    public class AccountLoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Must Be Entered")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(100, ErrorMessage = "Email is too long")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Must Be Entered")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
