using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Lib.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "First Name is required!")]
        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is required!")]
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
