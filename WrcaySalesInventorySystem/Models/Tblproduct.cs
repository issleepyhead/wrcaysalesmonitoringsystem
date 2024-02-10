using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tblproduct
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public double ProductPrice { get; set; }

    public double ProductCost { get; set; }

    public DateTime DateAdded { get; set; }

    public virtual Tblcategory? Category { get; set; }

    public virtual ICollection<Tbldelivery> Tbldeliveries { get; set; } = new List<Tbldelivery>();

    public virtual ICollection<Tbltransaction> Tbltransactions { get; set; } = new List<Tbltransaction>();
}
