using HandyControl.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
    public partial class CategoryPanel : UserControl, IUpdatePanels
    {
        private MainWindow mainWindow = Application.Current.Windows.Cast<MainWindow>().FirstOrDefault();
        private List<ViewModelCategory>? _data;
        public CategoryPanel()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new CategoryDialog(this));
        }

        //public void UpdateTable()
        //{
        //    _data = ViewModelCategory.getAll();

        //    CategoriesDataGridView.ItemsSource = _data.Take(30);
        //    Helpers.PaginationConfig(_data.Count, Pagination);
        //}

        private void CategoriesDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesDataGridView.SelectedItems.Count > 0)
            {
                ViewModelCategory vmCateg = (ViewModelCategory)CategoriesDataGridView.SelectedItem;
                Dialog.Show(new CategoryDialog(this, vmCateg));
            }
            CategoriesDataGridView.SelectedItems.Clear();
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            CategoriesDataGridView.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }

        public void UpdateUI()
        {
            _data = ViewModelCategory.getAll();

            CategoriesDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count, Pagination);
        }
    }
}
