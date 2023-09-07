using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Lib.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string? Initials { get; set; }

        public string LastName { get; set; } = null!;
    }
}
