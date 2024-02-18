using Microsoft.EntityFrameworkCore;
//using WrcaySalesInventorySystem.Models;
using WrcaySalesInventorySystem.ViewModel;

namespace SystemTesting
{
    [TestClass]
    public class CategoryTest
    {
        /*private ApplicationDatabaseContext databaseContext;
        public CategoryTest()
        {
            databaseContext = new(new DbContextOptions<ApplicationDatabaseContext>());
        }

        [TestMethod]
        public async Task CategoryTestForEmptyString()
        {
            Tblcategory category = new()
            {
                CategoryDescription = "Sample Description",
                CategoryName = "Test"
            };

            ViewModelCategory vmCategory = new ViewModelCategory(category, databaseContext);
            bool res = await vmCategory.Add();
            Assert.IsTrue(res, $"An error occured while adding the category {res}");
        }

        [TestMethod]
        public async Task CategoryDelete()
        {
            var categories = databaseContext.Tblcategories.ToArray<Tblcategory>();
            Tblcategory category = categories.First();
            databaseContext.Tblcategories.Remove(category);
            int res = await databaseContext.SaveChangesAsync();
            Assert.IsTrue(res > 0, "An error occured");
        }*/
    }
}