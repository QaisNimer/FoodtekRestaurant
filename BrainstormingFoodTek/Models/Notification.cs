using System;
using System.Collections.Generic;

namespace BrainstormingFoodTek.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int ReceiverId { get; set; }

    public string? Title { get; set; }

    public string? Message { get; set; }

    public int NotificationTypeId { get; set; }

    public bool? IsRead { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual LookupItem NotificationType { get; set; } = null!;

    public virtual User Receiver { get; set; } = null!;
}
