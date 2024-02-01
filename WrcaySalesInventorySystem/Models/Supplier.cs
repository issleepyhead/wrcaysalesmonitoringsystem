using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Models
{
    public class Supplier : IDataCommand
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
        [Column(TypeName = "VARCHAR")]
        public string? SupplierPhone { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage ="Email Address must be 150 characters or less.")]
        [DisplayName("Email")]
        [Column(TypeName = "VARCHAR")]
        public string? SupplierEmail { get; set; }

        public ICollection<Product>? Products { get; set; }

        public Task<bool> Add()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete()
        {
            throw new System.NotImplementedException();
        }

        public bool Exists()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsValid()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
