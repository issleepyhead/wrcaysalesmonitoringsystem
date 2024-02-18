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
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.Models;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
     
    public partial class ProductsPanel : UserControl
    {
        private readonly ApplicationDatabaseContext applicationDatabaseContext = new();
        private IEnumerable<Tblproduct>? _data;
        public ProductsPanel()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new ProductDialog(this));
        }

        public void UpdateTable()
        {
            _data = applicationDatabaseContext.Tblproducts.ToArray();

            ProductDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count(), Pagination);
        }

        private void ProductDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductDataGridView.SelectedItems.Count > 0)
            {
                Tblproduct product = (Tblproduct)ProductDataGridView.SelectedItem;
                ViewModelProduct vmCateg = new(product);
                Dialog.Show(new ProductDialog(this, vmCateg));
            }
            ProductDataGridView.SelectedItems.Clear();
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            ProductDataGridView.ItemsSource = _data.Skip((e.Info - 1) * 30).Take(30);
        }
    }
}
