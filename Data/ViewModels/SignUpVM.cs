using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.ViewModels
{
    public class SignUpVM
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address Is Required")]
        public string EmailAddress { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name Is Required")]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Re-Type Password Requird")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password dont match")]
        public string ConfirmPassword { get; set; }
    }
}
