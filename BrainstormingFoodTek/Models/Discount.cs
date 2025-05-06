using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string TitleEn { get; set; } = null!;

    public string TitleAr { get; set; } = null!;

    public string? DescriptionEn { get; set; }

    public string? DescriptionAr { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public string? Code { get; set; }

    public int? LimitUsage { get; set; }

    public string? ImageUrl { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
