using System;
using System.Collections.Generic;

namespace StudentManagementSystem.API.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? Initials { get; set; }

    public string LastName { get; set; } = null!;
}
