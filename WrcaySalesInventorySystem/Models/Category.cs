using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Data;

namespace WrcaySalesInventorySystem.Models
{
    internal class Category : IDataCommand
    {
        private ApplicationDatabaseContext applicationDatabaseContext = new ApplicationDatabaseContext();

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

        public async Task<bool> Add()
        {
            await applicationDatabaseContext.Categories.AddAsync(this);
            int created = await applicationDatabaseContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> Delete()
        {
            await applicationDatabaseContext.Categories.AddAsync(this);
            int created = await applicationDatabaseContext.SaveChangesAsync();
            return created > 0;
        }

        public bool Exists()
        {
            return applicationDatabaseContext.Categories.ToArray().Contains(this);
        }

        public Task<bool> IsValid()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update()
        {
            applicationDatabaseContext.Categories.Update(this);
            int created = await applicationDatabaseContext.SaveChangesAsync();
            return created > 0;
        }
    }
}
