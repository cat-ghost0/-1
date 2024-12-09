using System;
using System.Collections.Generic;

namespace PR1.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; } 

    public virtual ICollection<Administrator> Administrators { get; set; } = new List<Administrator>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Role Role { get; set; } = null!;
}
