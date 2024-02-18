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

    public int DiscountId { get; set; }

    public int VatId { get; set; }

    public DateTime DateAdded { get; set; }

    public virtual Tbldiscount Discount { get; set; } = null!;

    public virtual Tblproduct? Product { get; set; }

    public virtual Tbluser? User { get; set; }

    public virtual Tblvat Vat { get; set; } = null!;
}
