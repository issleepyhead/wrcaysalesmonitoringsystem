using HandyControl.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.custom;
using WrcaySalesInventorySystem.ViewModel;
using TextBox = HandyControl.Controls.TextBox;

namespace WrcaySalesInventorySystem.Dialogs
{
    /// <summary>
    /// Interaction logic for ProductDialog.xaml
    /// </summary>
    public partial class ProductDialog : UserControl
    {
        private ViewModelProduct _viewModel;
        private MainWindow? _mainWindow;

        public ProductDialog(ViewModelProduct? viewModel = null)
        {
            InitializeComponent();
            _mainWindow = Application.Current?.Windows.OfType<MainWindow>().FirstOrDefault<MainWindow>();
            if (viewModel != null)
            {
                _viewModel = viewModel;
                SaveButton.Content = "Update";
            }
            else
            {
                _viewModel = new();
                DeleteButton.Visibility = Visibility.Collapsed;
            }
            DataContext = _viewModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new BaseConnection().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM viewcategories", conn);
            DataTable dataTable = new();
            SqlDataAdapter adapter = new(cmd);
            adapter.Fill(dataTable);
            CategoryCombobox.ItemsSource = dataTable.DefaultView;
            CategoryCombobox.DisplayMemberPath = "category_name";
            CategoryCombobox.SelectedValuePath = "id";
            CategoryCombobox.SelectedIndex = 0;


             conn = new BaseConnection().getConnection();
            cmd = new SqlCommand("SELECT id, unit_name FROM tblproductunit", conn);
            dataTable = new();
             adapter = new(cmd);
            adapter.Fill(dataTable);


            SKUCombobox.ItemsSource = dataTable.DefaultView;
            SKUCombobox.DisplayMemberPath = "unit_name";
            SKUCombobox.SelectedValuePath = "id";
            SKUCombobox.SelectedIndex = 0;

        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryCombobox.SelectedIndex != -1)
                _viewModel.CategoryID = (int)CategoryCombobox.SelectedValue;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.Exists())
            {
                Growl.Info("Category already exists!");
                return;
            }

            IDataExecutor? command;
            if (_viewModel.ProductID != 0)
            {
                command = new UpdateCommand(_viewModel);
            }
            else
            {
                command = new AddCommand(_viewModel);
            }


            if (command != null && command.Execute())
            {
                Growl.Success((_viewModel?.ProductID != 0) ? "Product has been updated." : "Product has been added.");
                Helpers.CloseDialog(Closebtn);
            }
            else
                Growl.Error((_viewModel?.ProductID != 0) ? "Failed updating the product." : "Failed adding the product.");
            _mainWindow?.UpdateUI();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.Delete())
            {
                Growl.Success("Product has been deleted.");
                Helpers.CloseDialog(Closebtn);
            }
            else
            {
                Growl.Warning("Failed deleting product.");
            }
            _mainWindow?.UpdateUI();
        }

        private void SKUCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.ProductUnit = (int)SKUCombobox.SelectedValue;
        }

        private void ProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender.Equals(ProductNameTextBox))
            {
                Helpers.Check((TextBox)sender, ProductNameError, InputType.STRING_INPUT, "Please provide a valid name.");
            } else if (sender.Equals(ProductPriceTextBox))
            {
                Helpers.Check((TextBox)sender, ProductPriceError, InputType.NUMERIC_INPUT, "Please provide a valid price.");
                if (ProductPriceError.IsVisible)
                {
                    ProductCostError.Visibility = Visibility.Visible;
                } else
                {
                    ProductCostError.Visibility = Visibility.Collapsed;
                    ProductCostTextBox.BorderBrush = new BrushConverter().ConvertFromString("#FFE0E0E0") as Brush;
                }
            } else
            {
                Helpers.Check((TextBox)sender, ProductCostError, InputType.NUMERIC_INPUT, "Please provide a valid cost.");
                if(ProductCostError.IsVisible)
                {
                    ProductPriceError.Visibility = Visibility.Visible;
                } else
                {
                    ProductPriceError.Visibility = Visibility.Collapsed;
                    ProductPriceTextBox.BorderBrush = new BrushConverter().ConvertFromString("#FFE0E0E0") as Brush;
                }
            }
        }
    }

}

