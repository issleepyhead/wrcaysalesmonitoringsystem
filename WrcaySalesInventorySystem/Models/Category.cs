using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrcaySalesInventorySystem.Models
{
    internal class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Category Name must be 50 characters or less.")]
        [Column("CategoryName", TypeName = "VARCHAR")]
        public string? CategoryName { get; set; }

        [MaxLength(300, ErrorMessage = "Category Name must be 300 characters or less.")]
        public string? CategoryDescription { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
