namespace StudentManagementSystem
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public string? Instructor { get; set; }
        public IList<Enrollment>? Enrollments { get; set; }
    }
}
