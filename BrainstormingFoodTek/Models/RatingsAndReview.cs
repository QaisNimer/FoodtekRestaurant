using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class RatingsAndReview
{
    public int ReviewId { get; set; }

    public int ClientId { get; set; }

    public int OrderId { get; set; }

    public int? ItemId { get; set; }

    public int? CaptainId { get; set; }

    public int? RatingValue { get; set; }

    public string? ReviewText { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Client Client { get; set; } = null!;
}
