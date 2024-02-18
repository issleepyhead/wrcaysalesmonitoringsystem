using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.custom;
using WrcaySalesInventorySystem.Models;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.Dialogs
{
    /// <summary>
    /// Interaction logic for ProductDialog.xaml
    /// </summary>
    public partial class ProductDialog : UserControl
    {
        private ApplicationDatabaseContext dbContext = new();
        private readonly ViewModelProduct _vmModel;
        private readonly Tblproduct tblproduct = new();
        public ProductDialog(ProductsPanel productsPanel, ViewModelProduct? viewModel = null)
        {
            InitializeComponent();
            if (viewModel != null)
            {
                _vmModel = viewModel;
            }
            else
            {
                _vmModel = new ViewModelProduct(tblproduct);
            }
            DataContext = _vmModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CategoryComboBox.ItemsSource = dbContext.Tblcategories.ToArray();
            CategoryComboBox.DisplayMemberPath = "CategoryName";
            CategoryComboBox.SelectedValuePath = "Id";

        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vmModel.Category = (Tblcategory)CategoryComboBox.SelectedItem;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedValue == null)
            {
                CategoryError.Text = "Please select a category";
                CategoryError.Visibility = Visibility.Visible;
                return;
            }

            if (string.IsNullOrEmpty(ProductNameTextBox.Text.Trim()))
            {
                ProductNameError.Text = "Please provide a product name.";
                ProductNameError.Visibility = Visibility.Visible;
                return;
            }

            if (!Regex.IsMatch(ProductPriceTextBox.Text,@"^(\\d+)?\\.?(\\d+)$"))
            {
                ProductPriceError.Text = "Invalid price format.";
                ProductPriceError.Visibility = Visibility.Visible;
                return;
            }

            if (!Regex.IsMatch(ProductCostTextBox.Text, @"^(\\d+)?\\.?(\\d+)$"))
            {
                ProductCostError.Text = "Invalid cost format.";
                ProductCostError.Visibility = Visibility.Visible;
                return;
            }


            if (_vmModel.Exists())
            {
                Growl.Success("Product already exists.");
                return;
            }
            if (_vmModel.ProductID != 0)
            {
                if (_vmModel.Update())
                {
                    Growl.Success("Product has been updated successfully.");
                    Helpers.CloseDialog(Closebtn);
                }
                else
                {
                    Growl.Warning("Failed updating product.");
                }
            }
            else
            {
                if (_vmModel.Add())
                {
                    Growl.Success("Product has been added successfully.");
                    Helpers.CloseDialog(Closebtn);
                }
                else
                {
                    Growl.Warning("Failed adding new product.");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}

