using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.ViewModel;

namespace SystemTesting
{
    [TestClass]
    public class ProductTest
    {
        private ViewModelProduct _viewModel = new();


        // Add Product Test
        [TestMethod]
        public void TestAddProduct()
        {
            _viewModel.ProductName = "Yero";
            _viewModel.ProductDescription = null;
            _viewModel.ProductPrice = 10;
            _viewModel.ProductCost = 10;
            _viewModel.CategoryID = 98;
            AddCommand addCommand = new(_viewModel);
            bool res = addCommand.Execute();
            Assert.IsTrue(res, $"The result is {res}");
        }
    }
}
