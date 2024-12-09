using System;
using System.Collections.Generic;

namespace PR1.Models;

public partial class Administrator
{
    public int IdAdmin { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string ConfirmationCode { get; set; } = null!;

    public int UserInfo { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User UserInfoNavigation { get; set; } = null!;
}
