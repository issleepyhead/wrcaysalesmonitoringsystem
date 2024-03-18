using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.ViewModel;
using HandyControl.Controls;
using System.Linq;

namespace WrcaySalesInventorySystem.Dialogs
{
    public partial class DeliveryDialog : UserControl
    {
        string _refNo;
        ObservableCollection<ViewModelDeliveryCart> _data = new();
        public MainWindow? mainWindow = Application.Current?.Windows.OfType<MainWindow>().FirstOrDefault();
        public DeliveryDialog(string refno)
        {
            InitializeComponent();
            _refNo = refno;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new BaseConnection().getConnection();
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            try
            {
     
                if (_data != null)
                {
                    SqlCommand cmd;
                    foreach (ViewModelDeliveryCart cart in _data)
                    {
                        cmd = new("SELECT COUNT(*) FROM tblinventory WHERE product_id = @product_id", conn, sqlTransaction);
                        cmd.Parameters.AddWithValue("@product_id", cart.ProductID);
                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            cmd = new("UPDATE tblinventory SET stocks = stocks + @quantity, last_updated = GETDATE() WHERE product_id = @product_id",conn, sqlTransaction);
                            cmd.Parameters.AddWithValue("@quantity", cart.Quantity);
                            cmd.Parameters.AddWithValue("@product_id", cart.ProductID);
                        } else
                        {
                            cmd = new("INSERT INTO tblinventory VALUES(@pid, @quantity, @sold, @defective, GETDATE())", conn, sqlTransaction);
                            cmd.Parameters.AddWithValue("@pid", cart.ProductID);
                            cmd.Parameters.AddWithValue("@quantity", cart.Quantity);
                            cmd.Parameters.AddWithValue("@sold", 0);
                            cmd.Parameters.AddWithValue("@defective", 0);
                        }
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new("UPDATE tbldeliveryheader SET status_id = 2 WHERE reference_number = @refno", conn, sqlTransaction);
                    cmd.Parameters.AddWithValue("@refno", _refNo);
                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Growl.Success("Stocks has been added to inventory");
                    Helpers.CloseDialog(Closebtn);
                    mainWindow?.UpdateUI();
                }
            } catch
            {
                sqlTransaction.Rollback();
            } finally
            {
                conn.Dispose();
            }
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ReferenceNumberTextBlock.Text = _refNo;

            SqlConnection conn = new BaseConnection().getConnection();
            SqlCommand cmd = new("SELECT supplier_name, status_id FROM tbldeliveryheader t JOIN tblsuppliers s ON t.supplier_id = s.id WHERE reference_number = @refno", conn);
            cmd.Parameters.AddWithValue("@refno", _refNo);
            DataTable dataTable = new();
            SqlDataAdapter adapter = new(cmd);
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                SupplierName.Text = dataTable.Rows[0]["supplier_name"].ToString();
                if (dataTable.Rows[0]["status_id"].ToString() == "2")
                {
                    SaveButton.IsEnabled = false;
                    DeleteButton.IsEnabled = false;
                }
            }

            conn = new BaseConnection().getConnection();
            cmd = new("SELECT p.id, p.product_name, p.product_cost, d.quantity FROM tbldeliveries d JOIN tblproducts p ON d.product_id = p.id JOIN tbldeliveryheader h ON d.header_id = h.id WHERE h.reference_number = @refno", conn);
            cmd.Parameters.AddWithValue("@refno", _refNo);
            dataTable = new();
            adapter = new(cmd);
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                ViewModelDeliveryCart vm = new();
                vm.Cost = row["product_cost"].ToString();
                vm.ProductName = row["product_name"].ToString();
                vm.Quantity = row["quantity"].ToString();
                vm.ProductID = row["id"].ToString();
                _data.Add(vm);
               
            }
            ProductDataGridView.ItemsSource = _data;
        }
    }
}
