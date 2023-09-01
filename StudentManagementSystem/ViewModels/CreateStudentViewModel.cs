using StudentManagementSystem.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.WEB.ViewModels
{
    public class CreateStudentViewModel
    {
        [Required(ErrorMessage = "First Name is required!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Initials")]
        public string? Initials { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select the Gender!")]
        [Display(Name = "Gender")]
        public Gender? Gender { get; set; }

        [Display(Name = "Photo")]
        public IFormFile? Photo { get; set; }

        [Required(ErrorMessage = "Enrollment Date\" is required!")]
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }
        public IList<Enrollment>? Enrollments { get; set; }
    }
}
