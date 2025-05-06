using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class LookupType
{
    public int LookupTypeId { get; set; }

    public string LookupTypeName { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<LookupItem> LookupItems { get; set; } = new List<LookupItem>();
}
