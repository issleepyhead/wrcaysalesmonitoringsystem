using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tblrole
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Tbluser> Tblusers { get; set; } = new List<Tbluser>();
}
