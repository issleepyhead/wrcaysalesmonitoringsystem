using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WrcaySalesInventorySystem.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Category Name must be 50 characters or less.")]
        [Column(TypeName = "VARCHAR")]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }

        [MaxLength(300, ErrorMessage = "Category Name must be 300 characters or less.")]
        [Column(TypeName = "VARCHAR")]
        [DisplayName("Category Description")]
        public string? CategoryDescription { get; set; }

        public ICollection<Product>? Products { get; set; }
        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}
