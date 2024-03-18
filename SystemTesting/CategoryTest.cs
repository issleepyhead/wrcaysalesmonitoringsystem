using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.ViewModel;

namespace SystemTesting
{
    [TestClass]
    public class CategoryTest
    {
        private ViewModelCategory _vmCategory = new();

        [TestMethod]
        public void TestInsertCategory()
        {
            _vmCategory.CategoryName = "TestMethodCategory111";
            _vmCategory.CategoryDescription = null;
            AddCommand addCommand = new(_vmCategory);
            bool res = addCommand.Execute();
            Assert.IsTrue(res, $"The result is {res}");
        }


        [TestMethod]
        public void TestInsertWithoutName()
        {
            _vmCategory.CategoryName = null;
            _vmCategory.CategoryDescription = null;
            AddCommand addCommand = new(_vmCategory);
            bool res = addCommand.Execute();
            Assert.IsFalse(res, $"The result is {res}");
        }

        [TestMethod]
        public void TestUpdateCategory()
        {
            _vmCategory.CategoryName = "TestMethodCategory123";
            _vmCategory.CategoryDescription = "sample desc";
            _vmCategory.CategoryID = "";
            UpdateCommand updateCommand = new(_vmCategory);
            bool res = updateCommand.Execute();
            Assert.IsTrue(res, $"The result is {res}");
        }
    }
}