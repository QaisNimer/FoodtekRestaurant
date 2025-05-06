using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int CartId { get; set; }

    public int ClientId { get; set; }

    public double TotalPrice { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
