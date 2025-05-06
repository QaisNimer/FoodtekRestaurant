using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int RoleId { get; set; }

    public DateOnly JoinDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual User EmployeeNavigation { get; set; } = null!;

    public virtual LookupItem Role { get; set; } = null!;
}
