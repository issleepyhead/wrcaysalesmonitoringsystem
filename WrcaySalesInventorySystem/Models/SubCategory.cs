using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.Models
{
    public class SubCategory : IDataCommand
    {
        [Key]
        public int SubCategoryID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Category Name must be 50 characters or less.")]
        [Column(TypeName = "VARCHAR")]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }

        [MaxLength(300, ErrorMessage = "Category Name must be 300 characters or less.")]
        [DisplayName("Category Description")]
        [Column(TypeName = "VARCHAR")]
        public string? CategoryDescription { get; set; }

        public int? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category? Category { get; set; } = null;

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
