using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public int ClientId { get; set; }

    public int CardTypeId { get; set; }

    public string Last4Digits { get; set; } = null!;

    public DateOnly ExpiryDate { get; set; }

    public bool? IsDefault { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Client Client { get; set; } = null!;
}
