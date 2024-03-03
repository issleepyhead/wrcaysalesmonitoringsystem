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
            UpdateUI();
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Dialog.Show(new SubCategoryDialog());
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            SubCategoriesDataGridView.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }

        public void UpdateUI()
        {
            _data = ViewModelSubCategory.getAll();

            SubCategoriesDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count, Pagination);
        }

        private void CategoriesDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubCategoriesDataGridView.SelectedItems.Count > 0)
            {
                ViewModelSubCategory vmCateg = (ViewModelSubCategory)SubCategoriesDataGridView.SelectedItem;
                Dialog.Show(new SubCategoryDialog(vmCateg));
            }
            SubCategoriesDataGridView.SelectedItems.Clear();
        }

        private void SubCategoriesDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubCategoriesDataGridView.SelectedItems.Count > 0)
            {
                ViewModelSubCategory vmCateg = (ViewModelSubCategory)SubCategoriesDataGridView.SelectedItem;
                Dialog.Show(new SubCategoryDialog(vmCateg));
            }
            SubCategoriesDataGridView.SelectedItems.Clear();
        }
    }
}
