using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrcaySalesInventorySystem.Models
{
    internal class Role
    {
        [Key]
        public int RoleID  { get; set; }

        [Required]
        public string? RoleName { get; set; }
    }
}
