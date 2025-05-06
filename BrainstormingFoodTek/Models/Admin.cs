using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public int RoleId { get; set; }

    public DateOnly JoinDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateTime? LastLogin { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual User AdminNavigation { get; set; } = null!;

    public virtual LookupItem Role { get; set; } = null!;
}
