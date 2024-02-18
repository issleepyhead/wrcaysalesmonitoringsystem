using HandyControl.Controls;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.Models;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
    public partial class CategoryPanel : UserControl
    {
        private readonly ApplicationDatabaseContext applicationDatabaseContext = new();
        private IEnumerable<Tblcategory> _data;
        public CategoryPanel()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new CategoryDialog(this));
        }

        public void UpdateTable()
        {
            _data = applicationDatabaseContext.Tblcategories.ToArray();
      
            CategoriesDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count(), Pagination);
        }

        private void CategoriesDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesDataGridView.SelectedItems.Count > 0)
            {
                Tblcategory categ = (Tblcategory)CategoriesDataGridView.SelectedItem;
                ViewModelCategory vmCateg = new(categ);
                Dialog.Show(new CategoryDialog(this, vmCateg));
            }
            CategoriesDataGridView.SelectedItems.Clear();
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            CategoriesDataGridView.ItemsSource = _data.Skip((e.Info - 1) * 30).Take(30);
        }
    }
}
