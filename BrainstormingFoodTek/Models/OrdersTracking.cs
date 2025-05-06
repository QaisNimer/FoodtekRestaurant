using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class OrdersTracking
{
    public int TrackingId { get; set; }

    public int? OrderId { get; set; }

    public int CaptainId { get; set; }

    public string? CurrentStatus { get; set; }

    public string? LastUpdatedLocation { get; set; }

    public DateTime? EstimatedArrivalTime { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Delivery Captain { get; set; } = null!;

    public virtual Order? Order { get; set; }
}
