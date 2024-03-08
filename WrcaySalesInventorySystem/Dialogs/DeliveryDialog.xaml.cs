using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.Dialogs
{
    public partial class DeliveryDialog : UserControl
    {
        private DeliveryCartDialog _parent;
        private ViewModelDeliveryCart _vm;
        public DeliveryDialog(DeliveryCartDialog parent, ViewModelDeliveryCart? vm = null)
        {
            InitializeComponent();
            _parent = parent;
            if (vm != null)
                _vm = vm;
            else
                _vm = new();
            DataContext = _vm;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Helpers.Check(QuantityTextBox, QuantityError, Class.InputType.NUMERIC_INPUT, "Please provide a valid quantity."))
                return;

            bool exists = false;
            for(int i = 0; i < _parent?._data?.Count; i++)
            {
                if (_parent._data[i].ProductID == _vm.ProductID)
                {
                    _parent._data[i].Quantity = double.Parse(_parent._data[i].Quantity ?? "") + _vm.Quantity;
                    exists = true;
                    break;
                }

                if (exists)
                    _parent._data?.Add((ViewModelDeliveryCart)DataContext);
            }
            _vm.Total = double.Parse(_vm.Quantity ?? "") * _vm.Price;
            _parent?.UpdateData();
            Helpers.CloseDialog(Closebtn);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _parent?._data?.Remove((ViewModelDeliveryCart)DataContext);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ProductNameComboBox.ItemsSource = ViewModelProduct.getAll();
            ProductNameComboBox.DisplayMemberPath = "ProductName";
            ProductNameComboBox.SelectedValuePath = "ProductID";
            if(ProductNameComboBox.ItemsSource != null)
            {
                ProductNameComboBox.SelectedIndex = 0;
            }
        }

        private void ProductNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ProductNameComboBox.SelectedIndex != -1)
            {
                ViewModelProduct vm = (ViewModelProduct)ProductNameComboBox.SelectedItem;
                _vm.ProductName = vm.ProductName;
                _vm.ProductID = (int)ProductNameComboBox.SelectedValue;
                _vm.Cost = double.Parse(vm.ProductCost ?? "");
                _vm.Price = double.Parse(vm.ProductPrice ?? "");
            }
        }
    }
}
