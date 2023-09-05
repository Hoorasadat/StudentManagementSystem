using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }
        public int Credits { get; set; }

        [MaxLength(100)]
        public string? Instructor { get; set; }
        public IList<Enrollment>? Enrollments { get; set; }
    }
}
