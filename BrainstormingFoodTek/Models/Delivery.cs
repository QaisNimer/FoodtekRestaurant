using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class Delivery
{
    public int CaptainId { get; set; }

    public int VehicleTypeId { get; set; }

    public int? NumOfCompletedDeliveries { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual User Captain { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<OrdersTracking> OrdersTrackings { get; set; } = new List<OrdersTracking>();

    public virtual LookupItem VehicleType { get; set; } = null!;
}
