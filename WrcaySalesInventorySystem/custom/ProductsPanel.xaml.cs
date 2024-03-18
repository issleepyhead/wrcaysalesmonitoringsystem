using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.ViewModel;
using System.Collections.ObjectModel;

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

        private void ProductSearch_SearchStarted(object sender, HandyControl.Data.FunctionEventArgs<string> e)
        {
            ObservableCollection<ViewModelProduct> vmData = new();
            SqlConnection _sqlConnection = new BaseConnection().getConnection();
            try
            {
                SqlCommand _sqlCommand = new SqlCommand(
                    "SELECT * FROM viewtblproducts WHHER product_name LIKE @product_name",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@product_name", ProductSearch.Text);
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        ViewModelProduct vmCat = new();
                        if (data != null)
                        {
                            vmCat.ProductID = row["id"].ToString();
                            vmCat.CategoryID = row["category_id"].ToString();
                            vmCat.CategoryName = row["category_name"].ToString();
                            vmCat.ProductName = row["product_name"].ToString();
                            vmCat.ProductDescription = row["product_description"].ToString();
                            vmCat.ProductPrice = row["product_price"].ToString();
                            vmCat.ProductCost = row["product_cost"].ToString();
                            vmCat.ProductUnit = row["sku"].ToString();
                            vmCat.CreatedUser = row["created_by"].ToString();
                            vmCat.UpdatedUser = row["updated_by"].ToString();
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
