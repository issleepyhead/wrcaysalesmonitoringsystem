using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tbldelivery
{
    public int Id { get; set; }

    public int? SupplierId { get; set; }

    public int? ProductId { get; set; }

    public int? StatusId { get; set; }

    public string ReferenceNumber { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime DeliveryDate { get; set; }

    public DateTime DateAdded { get; set; }

    public virtual Tblproduct? Product { get; set; }

    public virtual Tblstatus? Status { get; set; }

    public virtual Tblsupplier? Supplier { get; set; }

    public virtual ICollection<Tblinventory> Tblinventories { get; set; } = new List<Tblinventory>();
}
