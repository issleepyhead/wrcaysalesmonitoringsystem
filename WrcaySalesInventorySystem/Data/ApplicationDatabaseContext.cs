using Microsoft.EntityFrameworkCore;
using WrcaySalesInventorySystem.Models;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem.Data
{
    internal class ApplicationDatabaseContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext>? options = null) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(Settings.Default.wrcaydbConnectionString)
                .UseSnakeCaseNamingConvention();
    }
}
