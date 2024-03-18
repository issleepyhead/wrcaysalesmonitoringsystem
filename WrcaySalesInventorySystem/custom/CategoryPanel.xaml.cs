using HandyControl.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.Properties;
using WrcaySalesInventorySystem.ViewModel;
using System.Collections.ObjectModel;

namespace WrcaySalesInventorySystem.custom
{
    public partial class CategoryPanel : UserControl, IUpdatePanels
    {
        private List<ViewModelCategory>? _data;
        public CategoryPanel()
        {
            InitializeComponent();
            UpdateUI();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new CategoryDialog());
        }

        private void CategoriesDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesDataGridView.SelectedItems.Count > 0)
            {
                ViewModelCategory vmCateg = (ViewModelCategory)CategoriesDataGridView.SelectedItem;
                Dialog.Show(new CategoryDialog(vmCateg));
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

        private void CategorySearch_SearchStarted(object sender, HandyControl.Data.FunctionEventArgs<string> e)
        {
            ObservableCollection<ViewModelCategory> vmData = new();
            SqlConnection _sqlConnection = new(Settings.Default.wrcaydbConnectionString);
            try
            {
                SqlCommand _sqlCommand = new SqlCommand(
                    "SELECT * FROM viewtblcategories WHERE category_name LIKE @category_name",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@category_name", CategorySearch.Text ?? "");
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    for (int i = 0; i < data?.Rows.Count; i++)
                    {
                        ViewModelCategory vmCat = new();
                        foreach (DataRow row in data.Rows)
                        {
                            vmCat.CategoryID = row["id"].ToString();
                            vmCat.CategoryName = row["category_name"].ToString();
                            vmCat.CategoryDescription = row["description"].ToString();
                            vmCat.CreatedBy = row["created_by"].ToString();
                            vmCat.UpdatedBy = row["updated_by"].ToString();
                            string x = row["date_added"].ToString() ?? "";
                            string y = row["date_updated"].ToString() ?? "";
                            vmCat.DateAdded = DateTime.Parse(x).ToShortDateString();
                            vmCat.DateUpdated = DateTime.Parse(y).ToShortDateString();
                        }
                        vmData.Add(vmCat);
                    }
                }
            }
            catch
            {
                Growl.Error("An error occured while performing the action.");
            }
            finally
            {
                _sqlConnection?.Dispose();
            }
        }
    }
}
