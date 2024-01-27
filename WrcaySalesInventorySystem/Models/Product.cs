using System.ComponentModel;
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
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }

        [Column("ProductDescription", TypeName = "VARCHAR")]
        [DisplayName("Product Description")]
        [MaxLength(300, ErrorMessage ="Product Descriptio must be 50 characters or less.")]
        public string? ProductDescription { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        [Required]
        public double ProductCost { get; set; }

        
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category? Category { get; set; }
    }
}
