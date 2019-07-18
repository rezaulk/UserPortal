using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserPortal.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegistrationViewModel
    {
        [Required]
        [Display(Name = "FirstName")] 
        public string FirstName { get; set; }

        [Required] 
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")] 
        public string Address { get; set; }

        [Required] 
        [Display(Name = "Phone")]
        public int Phone { get; set; }

        [Required]
        [Display(Name = "Email")] 
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required] 
        [Display(Name = "BirthDate")]
        public string BirthDate { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}