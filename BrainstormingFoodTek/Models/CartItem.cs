using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int CartId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
