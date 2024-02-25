using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.custom;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.Dialogs
{
    /// <summary>
    /// Interaction logic for ProductDialog.xaml
    /// </summary>
    public partial class ProductDialog : UserControl
    {
        //private readonly ApplicationDatabaseContext dbContext = new();
        //private readonly ViewModelProduct _vmModel;
        //private readonly Tblproduct tblproduct = new();
        public ProductDialog(ProductsPanel productsPanel, ViewModelProduct? viewModel = null)
        {
            InitializeComponent();
            //if (viewModel != null)
            //{
            //    _vmModel = viewModel;
            //}
            //else
            //{
            //    _vmModel = new ViewModelProduct(tblproduct);
            //}
            //DataContext = _vmModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //CategoryCheckCombobox.ItemsSource = dbContext.Tblcategories.ToArray();
            //CategoryCheckCombobox.DisplayMemberPath = "CategoryName";
            //CategoryCheckCombobox.SelectedValuePath = "Id";

        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_vmModel.Category = (Tblcategory)CategoryCheckCombobox.SelectedItem;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModelProduct _viewModel = new();
            _viewModel.ProductName = "Yero";
            _viewModel.ProductDescription = null;
            _viewModel.ProductPrice = 10;
            _viewModel.ProductCost = 10;
            _viewModel.CategoryID = 98;
            AddCommand addCommand = new(_viewModel);
            bool res = addCommand.Execute();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}

