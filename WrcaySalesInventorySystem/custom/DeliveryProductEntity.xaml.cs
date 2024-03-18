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
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.ViewModel;
using InputType = WrcaySalesInventorySystem.Class.InputType;

namespace WrcaySalesInventorySystem.Custom
{
    public partial class DeliveryProductEntity : UserControl
    {
        ViewModelDeliveryCart? entity;
        DeliveryCartDialog cartDialog;
        public DeliveryProductEntity(DeliveryCartDialog cartDialog,ViewModelDeliveryCart? cart = null)
        {
            InitializeComponent();
            entity = cart;
            this.cartDialog = cartDialog;
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
            if(entity != null)
            {
                ProductName.Text = entity.ProductName;
                QuantityNumeric.Value = Double.Parse(entity.Quantity ?? "1");
                ProductPrice.Text = "₱" + entity.Cost;
                
            }
        }

        private void QuantityNumeric_ValueChanged(object sender, HandyControl.Data.FunctionEventArgs<double> e)
        {
            if (entity != null)
            {
                entity.Quantity = QuantityNumeric.Value.ToString();
                cartDialog?.UpdateData();
            }
        }
    }
}
