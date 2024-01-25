using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WrcaySalesInventorySystem.Models
{
    internal class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Product Name must be 50 characters or less.")]
        [Column("ProductName", TypeName = "VARCHAR")]
        public string? ProductName { get; set; }

        [Column("ProductDescription", TypeName = "VARCHAR")]
        public string? ProductDescription { get; set; }

        
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category? Category { get; set; }
    }
}
