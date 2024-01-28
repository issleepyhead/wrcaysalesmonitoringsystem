using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WrcaySalesInventorySystem.Models
{
    class SubCategory
    {
        public int SubCategoryID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Category Name must be 50 characters or less.")]
        [Column("CategoryName", TypeName = "VARCHAR")]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }

        [MaxLength(300, ErrorMessage = "Category Name must be 300 characters or less.")]
        [DisplayName("Category Description")]
        public string? CategoryDescription { get; set; }

        public string? CategoryID { get; set; }
    }
}
