using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tblinventory
{
    public int Id { get; set; }

    public int DeliveryId { get; set; }

    public int StockIn { get; set; }

    public DateTime DateRecieved { get; set; }

    public virtual Tbldelivery Delivery { get; set; } = null!;
}
