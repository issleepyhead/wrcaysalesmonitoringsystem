using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WrcaySalesInventorySystem.ViewModel;
using InputType = WrcaySalesInventorySystem.Class.InputType;

namespace WrcaySalesInventorySystem.Custom
{
    /// <summary>
    /// Interaction logic for POSProductEntityxaml.xaml
    /// </summary>
    public partial class POSProductEntity : UserControl
    {
        private POSPanel _posPanel;
        private ViewModelDeliveryCart? _cart;
        public POSProductEntity(POSPanel pOSPanel, ViewModelDeliveryCart? cart)
        {
            InitializeComponent();
            _posPanel = pOSPanel;
            _cart = cart;
        }

        private void QuantityNumeric_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    e.Handled = true;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(QuantityNumeric.Value.ToString()))
            {
                if (e.Text == ".")
                {
                    string f = $"{QuantityNumeric.Value.ToString()}.00";
                    if (!ValidationCheck.ValidateInput(f, InputType.NUMERIC_INPUT))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_cart != null)
            {
                ProductName.Text = _cart.ProductName;
                QuantityNumeric.Value = Double.Parse(_cart.Quantity ?? "1");
                ProductPrice.Text = "₱" + _cart.Price;

            }
        }

        private void QuantityNumeric_ValueChanged(object sender, HandyControl.Data.FunctionEventArgs<double> e)
        {
            if (_cart != null)
            {
                _cart.Quantity = QuantityNumeric.Value.ToString();
            }
        }
    }


}
