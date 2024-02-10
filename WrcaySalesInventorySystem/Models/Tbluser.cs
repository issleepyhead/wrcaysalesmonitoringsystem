using System;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.Models;

public partial class Tbluser
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Contact { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public virtual Tblrole? Role { get; set; }

    public virtual ICollection<Tbllog> Tbllogs { get; set; } = new List<Tbllog>();

    public virtual ICollection<Tbltransaction> Tbltransactions { get; set; } = new List<Tbltransaction>();
}
