using System;
using System.Collections.Generic;

namespace PR1.Models;

public partial class Teacher
{
    public int IdTeach { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<CoursesAndTeacher> CoursesAndTeachers { get; set; } = new List<CoursesAndTeacher>();

    public virtual Role Role { get; set; } = null!;
}
