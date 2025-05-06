using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public int? DiscountId { get; set; }

    public decimal? DeliveryFee { get; set; }

    public int OrderStatusId { get; set; }

    public int? AssignedCaptainId { get; set; }

    public int? PaymentMethodId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Delivery? AssignedCaptain { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Discount? Discount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual LookupItem OrderStatus { get; set; } = null!;

    public virtual OrdersTracking? OrdersTracking { get; set; }
}
