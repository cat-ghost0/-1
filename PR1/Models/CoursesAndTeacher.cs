using System;
using System.Collections.Generic;

namespace PR1.Models;

public partial class CoursesAndTeacher
{
    public int IdCourAndTeach { get; set; }

    public int CoursesId { get; set; }

    public int TeacherId { get; set; }

    public virtual Course Courses { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
