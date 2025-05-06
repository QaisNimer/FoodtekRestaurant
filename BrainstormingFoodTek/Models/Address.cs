using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int ClientId { get; set; }

    public int RegionId { get; set; }

    public int ProvinceId { get; set; }

    public string? AddressDetails { get; set; }

    public string? Gpslocation { get; set; }

    public string? Title { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Client Client { get; set; } = null!;
}
