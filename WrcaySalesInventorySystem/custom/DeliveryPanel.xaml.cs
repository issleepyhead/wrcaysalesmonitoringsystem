using HandyControl.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
    /// <summary>
    /// Interaction logic for DeliveryPanel.xaml
    /// </summary>
    public partial class DeliveryPanel : UserControl, IUpdatePanels
    {
        private ObservableCollection<ViewModelDelivery>? _data;
        public DeliveryPanel()
        {
            InitializeComponent();
            UpdateUI();
        }

        public void UpdateUI()
        {
            _data = ViewModelDelivery.getAll();

            DeliveryDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count, Pagination);
        }

        private void DeliveryAddDeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new DeliveryCartDialog());
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            DeliveryDataGridView.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }

        private void DeliveryDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if (DeliveryDataGridView.SelectedItems.Count > 0)
            {
                ViewModelDelivery vmCateg = (ViewModelDelivery)DeliveryDataGridView.SelectedItem;
                if (!string.IsNullOrEmpty(vmCateg.ReferenceNumber))
                    Dialog.Show(new DeliveryDialog(vmCateg.ReferenceNumber));
            }
        }
    }
}
