using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tblvat
{
    public int Id { get; set; }

    public string VatName { get; set; } = null!;

    public double VatValue { get; set; }

    public virtual ICollection<Tbltransaction> Tbltransactions { get; set; } = new List<Tbltransaction>();
}
