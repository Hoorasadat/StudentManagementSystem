using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Lib.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? Initials { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? ImageFile { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public IList<Enrollment>? Enrollments { get; set; }

    }
}
