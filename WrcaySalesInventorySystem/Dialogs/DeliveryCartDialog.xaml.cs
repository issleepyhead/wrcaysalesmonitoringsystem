using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.Dialogs
{
    public partial class DeliveryCartDialog : UserControl
    {
        public List<ViewModelDeliveryCart> _data = new();
        public string? _reference = null;
        public DeliveryCartDialog(string? reference = null)
        {
            InitializeComponent();
            if (reference != null)
            {
                RecievedButton.Visibility = System.Windows.Visibility.Visible;
                CancelButton.Visibility = System.Windows.Visibility.Visible;
                SaveButton.Visibility = System.Windows.Visibility.Collapsed;
            }
            DeliveryDate.SelectedDate = DateTime.Now;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SupplierNameComboBox.ItemsSource = ViewModelSupplier.getAll();
            SupplierNameComboBox.DisplayMemberPath = "SupplierName";
            SupplierNameComboBox.SelectedValuePath = "SupplierID";
            if(SupplierNameComboBox.ItemsSource != null)
            {
                SupplierNameComboBox.SelectedIndex = 0;
            }
        }

        private void AddItemButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Dialog.Show(new DeliveryDialog(this));
        }

        public void UpdateData()
        {
            ItemsDataGridView.ItemsSource = _data;
            double total = 0;
            for(int i  = 0; i < _data.Count; i++)
            {
                total += _data[i].Price;
            }
            CostPrice.Text = total.ToString();
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void RecievedButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DeliveryDate.SelectedDate == DateTime.Now)
            {

            } else
            {
                string tempid = "";
                string tempquantity = "";
                for( int i = 0; i < _data.Count; i++)
                {
                    tempid += $"{_data[i].ProductID},";
                    tempquantity += $"{_data[i].Quantity},";
                }
                tempid = tempid.TrimEnd(',');
                tempquantity = tempquantity.Trim(',');
            }
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
