using StudentManagementSystem.Lib.Models;

namespace StudentManagementSystem.WEB.ViewModels
{
    public class CreateStudentViewModel
    {
        public string? FirstName { get; set; }
        public string? Initials { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public string? ImageFile { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public IList<Enrollment>? Enrollments { get; set; }
    }
}
