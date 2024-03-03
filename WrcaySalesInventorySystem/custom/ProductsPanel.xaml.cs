using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{

    public partial class ProductsPanel : UserControl, IUpdatePanels
    {
        private List<ViewModelProduct>? _data;
        public ProductsPanel()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new ProductDialog());
        }

        private void ProductDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductDataGridView.SelectedItems.Count > 0)
            {
                ViewModelProduct product = (ViewModelProduct)ProductDataGridView.SelectedItem;
                Dialog.Show(new ProductDialog(product));
            }
            ProductDataGridView.SelectedItems.Clear();
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            ProductDataGridView.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }

        public void UpdateUI()
        {
            _data = ViewModelProduct.getAll();

            ProductDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count(), Pagination);
        }
    }
}
