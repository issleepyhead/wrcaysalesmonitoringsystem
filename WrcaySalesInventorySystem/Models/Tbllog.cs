using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tbllog
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Action { get; set; } = null!;

    public string ObjectCategory { get; set; } = null!;

    public string ObjectActedOn { get; set; } = null!;

    public DateTime? DateAdded { get; set; }

    public TimeSpan? TimeAdded { get; set; }

    public virtual Tbluser? User { get; set; }
}
