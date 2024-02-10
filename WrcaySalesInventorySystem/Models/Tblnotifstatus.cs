using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tblnotifstatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Tbltransaction> Tbltransactions { get; set; } = new List<Tbltransaction>();
}
