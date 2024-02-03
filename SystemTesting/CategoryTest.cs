using WrcaySalesInventorySystem.Models;
using WrcaySalesInventorySystem.Data;

namespace SystemTesting
{
    [TestClass]
    public class CategoryTest
    {
        private ApplicationDatabaseContext databaseContext = new ApplicationDatabaseContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDatabaseContext>());
        public CategoryTest()
        {
            
        }

        [TestMethod]
        public void CategoryTestForEmptyString()
        {
            databaseContext.Categories.Add(
            {
                CategoryName = "Jamari",
                CategoryDescription = "Something"
            });

            if (databaseContext.SaveChanges() < 0)
            {
                throw new Exception("Error");
            } else
            {

            }
        }
    }
}