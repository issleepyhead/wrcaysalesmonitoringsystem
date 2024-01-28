using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WrcaySalesInventorySystem.Models
{
    internal class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="Supplier Name must be 100 characters or less.")]
        [DisplayName("Supplier Name")]
        public string? SupplierName { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage ="Phone Number must be 25 characters or less.")]
        [DisplayName("Phone")]
        public string? SupplierPhone { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage ="Email Address must be 150 characters or less.")]
        [DisplayName("Email")]
        public string? SupplierEmail { get; set; }


    }
}
