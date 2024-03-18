using HandyControl.Controls;
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

namespace WrcaySalesInventorySystem.Dialogs
{
    /// <summary>
    /// Interaction logic for POSDialog.xaml
    /// </summary>
    public partial class POSDialog : UserControl
    {
        POSPanel _posPanel;
        public POSDialog(POSPanel pOSPanel)
        {
            InitializeComponent();
            _posPanel = pOSPanel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AdditionalTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    e.Handled = true;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(((HandyControl.Controls.TextBox)sender).Text))
            {
                if (e.Text == ".")
                {
                    string f = $"{((HandyControl.Controls.TextBox)sender).Text}.00";
                    if (!ValidationCheck.ValidateInput(f, InputType.NUMERIC_INPUT))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void ProcessData()
        {
            double total = 0d;
            foreach (ViewModelDeliveryCart cart in _posPanel._data)
            {
                double.TryParse(cart.Quantity, out double quantity);
                double.TryParse(cart.Price, out double price);
                total += quantity * price;
            }
            SubTotalTextBlock.Text = total.ToString("0.00");

            if (!string.IsNullOrEmpty(AdditionalTextBox.Text) && double.TryParse(AdditionalTextBox.Text, out double d))
            {

            }

            if (!string.IsNullOrEmpty(DiscountTextBox.Text) && double.TryParse(DiscountTextBox.Text, out double dd))
            {
                 
            }

            if (!string.IsNullOrEmpty(AmountTextBox.Text) && double.TryParse(AmountTextBox.Text, out double aa))
            {
                double.TryParse(GrandTotal.Text, out double g);
                double.TryParse(AmountTextBox.Text, out double a);
                ChangeTextBlock.Text = (a - g).ToString("0.00");
            }
        }
    }
}
