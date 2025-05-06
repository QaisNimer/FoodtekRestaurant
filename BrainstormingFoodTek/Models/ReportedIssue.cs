using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class ReportedIssue
{
    public int IssueId { get; set; }

    public int ClientId { get; set; }

    public int OrderId { get; set; }

    public int IssueTypeId { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? AdminResponse { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Client Client { get; set; } = null!;
}
