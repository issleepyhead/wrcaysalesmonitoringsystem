using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrcaySalesInventorySystem.Models
{
    internal class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="Supplier Name must be 100 characters or less.")]
        public string? SupplierName { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage ="Phone Number must be 25 characters or less.")]
        public string? SupplierPhone { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage ="Email Address must be 150 characters or less.")]
        public string? SupplierEmail { get; set; }


    }
}
