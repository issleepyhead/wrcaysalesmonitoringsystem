using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WrcaySalesInventorySystem.Models
{
    internal class Sale
    {
        [Key]
        public int SaleID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        [Column(TypeName ="DATETIME")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
