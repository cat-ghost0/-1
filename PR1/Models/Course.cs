using System;
using System.Collections.Generic;

namespace PR1.Models;

public partial class Course
{
    public int IdCour { get; set; }

    public string Name { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public int MaxEnrollment { get; set; }

    public int CurrentEnrollment { get; set; }

    public virtual ICollection<CoursesAndTeacher> CoursesAndTeachers { get; set; } = new List<CoursesAndTeacher>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
