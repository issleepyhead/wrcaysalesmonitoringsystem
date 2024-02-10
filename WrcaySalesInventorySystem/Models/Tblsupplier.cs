using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tblsupplier
{
    public int Id { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierAddress { get; set; } = null!;

    public string SupplierContact { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public virtual ICollection<Tbldelivery> Tbldeliveries { get; set; } = new List<Tbldelivery>();
}
