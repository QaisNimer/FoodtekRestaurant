using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string? ImagePath { get; set; }

    public bool? IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
