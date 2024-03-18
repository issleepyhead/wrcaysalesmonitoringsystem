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

        private void SupplierSearch_SearchStarted(object sender, HandyControl.Data.FunctionEventArgs<string> e)
        {
            ObservableCollection<ViewModelSupplier> vmData = new();
            SqlConnection _sqlConnection = new BaseConnection().getConnection();
            try
            {
                SqlCommand _sqlCommand = new(
                    "SELECT * FROM viewtblsuppliers WHERE supplier_name LIKE @supplier_name",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@supplier_name", SupplierSearch.Text ?? "");
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    for (int i = 0; i < data?.Rows.Count; i++)
                    {
                        ViewModelSupplier vmCat = new();
                        if (data != null)
                        {
                            vmCat.SupplierID = (int)data.Rows[i][0];
                            vmCat.SupplierName = data.Rows[i][1].ToString();
                            vmCat.SupplierFirstName = data.Rows[i][2].ToString();
                            vmCat.SupplierLastName = data.Rows[i][3].ToString();
                            vmCat.SupplierCity = data.Rows[i][4].ToString();
                            vmCat.SupplierCountry = data.Rows[i][5].ToString();
                            vmCat.SupplierAddress = data.Rows[i][6].ToString();
                            vmCat.SupplierPhone = data.Rows[i][7].ToString();
                            vmCat.CreatedUser = data.Rows[i][8].ToString();
                            vmCat.UpdatedUser = data.Rows[i][9].ToString();
                            string x = data.Rows[i][10].ToString() ?? "";
                            string y = data.Rows[i][11].ToString() ?? "";
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
