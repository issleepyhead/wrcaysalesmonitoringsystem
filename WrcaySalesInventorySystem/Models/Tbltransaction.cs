using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tbltransaction
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public int Quantity { get; set; }

    public double TotalAmount { get; set; }

    public DateTime DateAdded { get; set; }

    public int StatusId { get; set; }

    public virtual Tblproduct? Product { get; set; }

    public virtual Tblnotifstatus Status { get; set; } = null!;

    public virtual Tbluser? User { get; set; }
}
