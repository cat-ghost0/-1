using System;
using System.Collections.Generic;

namespace PR1.Models;

public partial class Enrollment
{
    public int IdEnroll { get; set; }

    public int UserId { get; set; }

    public int CoursesId { get; set; }

    public DateOnly DateEnrollments { get; set; }

    public virtual Course Courses { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
