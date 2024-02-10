using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tblcategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public DateTime DateAdded { get; set; }

    public virtual ICollection<Tblproduct> Tblproducts { get; set; } = new List<Tblproduct>();
}
