using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.WEB.ViewModels
{
    public class CreateCourseViewModel
    {
        [Required]
        [Range(1, 1000, ErrorMessage = "Id must be a number between 1 and 10,000!")]
        public int Id { get; set; }


        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }


        [Required]
        [Range(1, 4, ErrorMessage = "Creadits must be a number between 1 and 4!")]
        public int Credits { get; set; }


        [Required(ErrorMessage = "Please select an Instructor!")]
        [MaxLength(100)]
        public string? Instructor { get; set; }


        public IList<Enrollment>? Enrollments { get; set; }
    }
}
