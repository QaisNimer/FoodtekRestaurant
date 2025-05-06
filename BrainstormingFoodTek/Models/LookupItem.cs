using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class LookupItem
{
    public int LookupItemId { get; set; }

    public int LookupTypeId { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual LookupType LookupType { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<User> UserStatuses { get; set; } = new List<User>();

    public virtual ICollection<User> UserUserTypes { get; set; } = new List<User>();
}
