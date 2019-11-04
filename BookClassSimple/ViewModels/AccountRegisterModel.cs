using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookClassSimple.Models
{
    public class AccountRegisterViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Must Be Entered")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(100, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Must Be Entered")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [MaxLength(20, ErrorMessage = "Phone Number is too long")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Must Be Entered")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Password Must Be Entered")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Comfirmed Password is Different from Password")]
        public string ConfirmPassword { get; set; }
    }
}
