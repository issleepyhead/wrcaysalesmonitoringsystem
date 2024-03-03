using HandyControl.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
    public partial class SupplierPanel : UserControl, IUpdatePanels
    {
        private List<ViewModelSupplier>? _data;
        public SupplierPanel()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new SupplierDialog());
        }

        public void UpdateUI()
        {
            _data = ViewModelSupplier.getAll();

            SuppliersDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count, Pagination);
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            SuppliersDataGridView.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }

        private void SuppliersDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SuppliersDataGridView.SelectedItems.Count > 0)
            {
                ViewModelSupplier vmCateg = (ViewModelSupplier)SuppliersDataGridView.SelectedItem;
                Dialog.Show(new SupplierDialog(vmCateg));
            }
            SuppliersDataGridView.SelectedItems.Clear();
        }
    }
}
