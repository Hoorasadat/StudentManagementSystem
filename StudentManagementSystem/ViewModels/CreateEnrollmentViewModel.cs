using StudentManagementSystem.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.WEB.ViewModels
{
    public class CreateEnrollmentViewModel
    {
        [Required(ErrorMessage = "Please select a course"), Display(Name = "Course")]
        public int? CourseID { get; set; }


        [Required(ErrorMessage = "Please select a student!")]
        [Display(Name = "Student")]
        public int? StudentID { get; set; }


        public Grade? Grade { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
