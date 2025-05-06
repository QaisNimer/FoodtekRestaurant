using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class OrderItem
{
    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public int? Quantity { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
