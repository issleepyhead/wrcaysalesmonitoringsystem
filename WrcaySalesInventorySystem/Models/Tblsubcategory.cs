using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tblsubcategory
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public int? ParentId { get; set; }
}
