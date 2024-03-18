using HandyControl.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.Properties;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
    public partial class AccountPanel : UserControl, IUpdatePanels
    {
        private List<ViewModelUser>? _data;
        public AccountPanel()
        {
            InitializeComponent();
            UpdateUI();
        }

        public void UpdateUI()
        {
            _data = ViewModelUser.getAll();

            AccountsDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count, Pagination);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new UserDialog());
        }

        private void AccountsDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccountsDataGridView.SelectedItems.Count > 0)
            {
                ViewModelUser vmCateg = (ViewModelUser)AccountsDataGridView.SelectedItem;
                Dialog.Show(new UserDialog(vmCateg));
            }
            AccountsDataGridView.SelectedItems.Clear();
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            AccountsDataGridView.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }

        private void SalesSearch_SearchStarted(object sender, HandyControl.Data.FunctionEventArgs<string> e)
        {
            ObservableCollection<ViewModelUser> vmData = new();
            SqlConnection _sqlConnection = new(Settings.Default.wrcaydbConnectionString);
            try
            {
                SqlCommand _sqlCommand = new SqlCommand(
                    "SELECT * FROM viewtblusers WHERE first_name LIKE @first_name OR last_name LIKE @last_name",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@first_name", SalesSearch.Text ?? "");
                _sqlCommand.Parameters.AddWithValue("@last_name", SalesSearch.Text ?? "");
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    for (int i = 0; i < data?.Rows.Count; i++)
                    {
                        ViewModelUser vmCat = new();
                        foreach (DataRow row in data.Rows)
                        {
                            vmCat.UserID = row["ID"].ToString();
                            vmCat.FirstName = row["first_name"].ToString();
                            vmCat.LastName = row["last_name"].ToString();
                            vmCat.RoleName = row["ROLE"].ToString();
                            vmCat.Address = row["ADDRESS"].ToString();
                            vmCat.Contact = row["CONTACT"].ToString();
                            vmCat.UserName = row["USERNAME"].ToString();
                            vmCat.Password = row["PASSWORD"].ToString();
                            vmCat.DateCreated = row["DATE_CREATED"].ToString();
                            vmCat.RoleID = row["RoleID"].ToString();
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
