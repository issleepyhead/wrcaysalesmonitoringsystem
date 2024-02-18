using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tbldiscount
{
    public int Id { get; set; }

    public string DiscountName { get; set; } = null!;

    public double DiscountValue { get; set; }

    public virtual ICollection<Tbltransaction> Tbltransactions { get; set; } = new List<Tbltransaction>();
}
