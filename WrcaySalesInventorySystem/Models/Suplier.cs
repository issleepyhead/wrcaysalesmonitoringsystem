using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrcaySalesInventorySystem.Models
{
    internal class Suplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        public string? SupplierName { get; set; }

        [Required]
        public string? SupplierPhone { get; set; }

        [Required]
        public string? SupplierEmail { get; set; }


    }
}
