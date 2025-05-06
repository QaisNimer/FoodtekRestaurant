using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class FavoriteItem
{
    public int ClientId { get; set; }

    public int ItemId { get; set; }

    public string EnglishName { get; set; }

    public string ArabicName { get; set; }

    public string EnglishDescription { get; set; }

    public string ArabicDescription { get; set; }

    public decimal Price { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public int Id { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
