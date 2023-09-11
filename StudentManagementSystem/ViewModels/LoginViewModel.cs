using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.WEB.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required!")]
        [MaxLength(100)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Invalid Email format!")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Password is required!")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
