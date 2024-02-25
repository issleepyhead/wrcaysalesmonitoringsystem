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
using InputType = WrcaySalesInventorySystem.Class.InputType;
using TextBox = HandyControl.Controls.TextBox;

namespace WrcaySalesInventorySystem.Dialogs
{
    /// <summary>
    /// Interaction logic for SupplierDialog.xaml
    /// </summary>
    public partial class SupplierDialog : UserControl
    {
        public SupplierDialog()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender.Equals(SupplierContactTextBox))
            {
                Check((TextBox)sender, ContactError, InputType.PHONE_INPUT, "Please provide a valid mobile number.");
            } else if (sender.Equals(SupplierFirstNameTextBox))
            {
                Check((TextBox)sender, FirstNameError, InputType.STRING_INPUT, "Please provide a first name.");
            } else if (sender.Equals(SupplierLastNameTextBox))
            {
                Check((TextBox)sender, LastError, InputType.STRING_INPUT, "Please provide a last name.");
            } else if (sender.Equals(SupplierAddressTextBox))
            {
                Check((TextBox)sender, AddressError, InputType.STRING_INPUT, "Please provide an address.");
            } else
            {
                Check((TextBox)sender, CompanyError, InputType.STRING_INPUT, "Please provide a supplier name.");
            }

        }

        private void Check(TextBox textBox, TextBlock txtBlock, InputType type, string errortxt)
        {
            if (!ValidationCheck.ValidateInput(textBox.Text, type))
            {
                textBox.BorderBrush = Brushes.Red;
                txtBlock.Visibility = Visibility.Visible;
                txtBlock.Text = errortxt;
            }
            else
            {
                textBox.BorderBrush = new BrushConverter().ConvertFromString("#FFE0E0E0") as Brush;
                txtBlock.Visibility = Visibility.Collapsed;
                txtBlock.Text = null;
            }
        }
    }
}
