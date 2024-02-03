using WrcaySalesInventorySystem.Models;
using WrcaySalesInventorySystem.Data;
using Microsoft.EntityFrameworkCore;

namespace SystemTesting
{
    [TestClass]
    public class CategoryTest
    {
        private ApplicationDatabaseContext databaseContext;
        public CategoryTest()
        {
            databaseContext = new(new DbContextOptions<ApplicationDatabaseContext>());
        }

        [TestMethod]
        public void CategoryTestForEmptyString()
        {
            databaseContext.Categories.Add(new Category
            {
                CategoryName = "Jamargsegesi",
                CategoryDescription = "Somfrawfawethings"
            });

            Assert.IsFalse(databaseContext.SaveChanges() < 0, "Nag save pare!");
        }

        //[TestMethod]
        //public void CategoryTestForNullString()
        //{
        
        //}

        //[TestMethod]
        //public void CategoryTestForNullCategory()
        //{

        //}
    }
}