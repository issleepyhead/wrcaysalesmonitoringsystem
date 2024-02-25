using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
    public partial class SubCategory : UserControl, IUpdatePanels
    {
        private List<ViewModelSubCategory>? _data;
        public SubCategory()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Dialog.Show(new SubCategoryDialog());
        }

        public void UpdateTable()
        {
            _data = ViewModelSubCategory.getAll();

            SubCategoriesDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count, Pagination);
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            SubCategoriesDataGridView.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }

        public void UpdateUI()
        {
            //throw new NotImplementedException();
        }
    }
}
