using StudentManagementSystem.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.WEB.ViewModels
{
    public class AddGradeViewModel
    {
        public int Id { get; set; }


        public int CourseId { get; set; }


        public int StudentId { get; set; }


        [Required(ErrorMessage ="Please select a grade!")]
        public Grade? Grade { get; set; }


        [Display(Name = "Course")]
        public string? CourseTitle { get; set; }


        [Display(Name = "Student")]
        public string? StudentName { get; set; }

        public Student? Student { get; set; }


        public Course? Course { get; set; }
    }
}
