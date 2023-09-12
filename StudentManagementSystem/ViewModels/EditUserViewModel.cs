using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.WEB.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>();
        }


        public string Id { get; set; }


        [Required(ErrorMessage = "First Name is required!")]
        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is required!")]
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Email is required!")]
        [MaxLength(100)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Invalid Email format!")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Username is required!")]
        [MaxLength(100)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Invalid Username format!")]
        public string Username { get; set; }


        public IList<string> Roles { get; set; }

    }
}
