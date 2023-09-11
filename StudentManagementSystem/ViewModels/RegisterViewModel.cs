using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.WEB.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required!")]
        [MaxLength(100)]
        [RegularExpression(@"^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$", ErrorMessage = "Invalid Email!")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Password is required!")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "Confirm Password is required!")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        [Compare("Password", ErrorMessage ="Password and Confirm Password must mach!")]
        public string ConfirmPassword { get; set; }
    }
}
