using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Xaml;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Custom;
using WrcaySalesInventorySystem.Properties;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.Dialogs
{
    public partial class DeliveryCartDialog : UserControl
    {
        public ObservableCollection<ViewModelDeliveryCart> _data = new();
        public string? _reference = null;
        public MainWindow? mainWindow = Application.Current?.Windows.OfType<MainWindow>().FirstOrDefault();
        public DeliveryCartDialog()
        {
            InitializeComponent();
            //if (reference != null)
            //{
            //    RecievedButton.Visibility = System.Windows.Visibility.Visible;
            //    CancelButton.Visibility = System.Windows.Visibility.Visible;
            //    SaveButton.Visibility = System.Windows.Visibility.Collapsed;
            //}
            DeliveryDate.SelectedDate = DateTime.Now;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            GenerateReference();
            SqlConnection conn = new BaseConnection().getConnection();
            SqlCommand cmd = new("SELECT id, supplier_name FROM tblsuppliers", conn);
            DataTable dataTable = new();
            SqlDataAdapter adapter = new(cmd);
            adapter.Fill(dataTable);
            SupplierNameComboBox.ItemsSource = dataTable.DefaultView;
            SupplierNameComboBox.DisplayMemberPath = "supplier_name";
            SupplierNameComboBox.SelectedValuePath = "id";
            SupplierNameComboBox.SelectedIndex = 0;
        }

        //private void AddItemButton_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    Dialog.Show(new DeliveryDialog(this));
        //}

        public void UpdateData()
        {
            double total = 0d;
            foreach (ViewModelDeliveryCart cart in _data)
            {
                if(!string.IsNullOrEmpty(cart.Cost) && !string.IsNullOrEmpty(cart.Quantity))
                {
                    double.TryParse(cart.Cost, out double a);
                    double.TryParse(cart.Quantity, out double b);

                    total += a * b;
                }
            }
            SubtotalTextBlock.Text = total.ToString("0.00");

            if (!string.IsNullOrEmpty(AdditionalTextBox.Text) && double.TryParse(AdditionalTextBox.Text, out double res))
            {
                total += double.Parse(AdditionalTextBox.Text);
            }
            GrandTotalTextBlock.Text = total.ToString("0.00");
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        public void GenerateReference()
        {
            SqlConnection conn = new BaseConnection().getConnection();
            try
            {
                SqlCommand cmd = new("SELECT COUNT(*) FROM tbldeliveryheader", conn);
                int c = (int)cmd.ExecuteScalar() + 1;
                ReferenceNumberTextBlock.Text = c.ToString().PadLeft(10 - c.ToString().Length, '0');
            } catch
            {
                
            } finally
            {
                conn.Dispose();
            }
        }

        private void ProductSearch_SearchStarted(object sender, HandyControl.Data.FunctionEventArgs<string> e)
        {
            SqlConnection conn = new BaseConnection().getConnection();
            SqlCommand cmd = new("SELECT p.id, p.product_name, p.product_cost, t.stocks FROM tblinventory t RIGHT JOIN tblproducts p ON t.product_id = p.id WHERE p.product_name LIKE @product_name", conn);
            cmd.Parameters.AddWithValue("@product_name", ProductSearch.Text);
            DataTable dataTable = new();
            SqlDataAdapter adapter = new(cmd);
            adapter.Fill(dataTable);

            ObservableCollection<ViewModelDeliveryCart> source = new ObservableCollection<ViewModelDeliveryCart>();
            foreach(DataRow row in dataTable.Rows)
            {
                ViewModelDeliveryCart vm = new();
                vm.Cost = row["product_cost"].ToString();
                vm.ProductName = row["product_name"].ToString();
                vm.ProductID = row["id"].ToString();
                vm.StocksAvailable = row["stocks"].ToString();
                source.Add(vm);
            }
            ProductDataGridView.ItemsSource = source;
            
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ProductDataGridView.SelectedItems.Count > 0)
            {
                ViewModelDeliveryCart cart = (ViewModelDeliveryCart)ProductDataGridView.SelectedItem;
                bool exists = false;
                foreach (ViewModelDeliveryCart item in _data)
                {
                    if (item.ProductName == cart.ProductName)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    cart.Quantity = "1";
                    _data.Add(cart);
                }
            }
            ProductCartList.Children.Clear();
            foreach (ViewModelDeliveryCart cart in _data)
            {
                ProductCartList.Children.Add(new DeliveryProductEntity(this, cart));
            }
            UpdateData();
        }

        private void AdditionalTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach(char c in e.Text)
            {
                if(!char.IsDigit(c) && c != '.')
                {
                    e.Handled = true;
                    break; 
                }
            }

            if (!string.IsNullOrEmpty(AdditionalTextBox.Text))
            {
                if (e.Text == ".")
                {
                    string f = $"{AdditionalTextBox.Text}.00";
                    if (!ValidationCheck.ValidateInput(f, InputType.NUMERIC_INPUT))
                    {
                        e.Handled = true;
                    }
                }
            }
            UpdateData();
        }

        private void AddDelivery_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new BaseConnection().getConnection();
            try
            {
                
                SqlCommand sqlCommand = new("InsertDeliveryProcedure @supplier_id, @reference_number, @additional_fee, @total_cost, @delivery_date, @user_id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@supplier_id", SupplierNameComboBox.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@reference_number", ReferenceNumberTextBlock.Text);
                sqlCommand.Parameters.AddWithValue("@additional_fee", string.IsNullOrEmpty(AdditionalTextBox.Text) ? DBNull.Value : AdditionalTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@total_cost", GrandTotalTextBlock.Text);
                sqlCommand.Parameters.AddWithValue("@delivery_date", DeliveryDate.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@user_id", Settings.Default.userID);
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                    try
                    {
                        
                        foreach (ViewModelDeliveryCart cart in _data)
                        {
                            sqlCommand = new SqlCommand("INSERT INTO tbldeliveries VALUES ((SELECT TOP 1 id FROM tbldeliveryheader ORDER BY id DESC), @pid, @quantity)", sqlConnection, sqlTransaction);
                            sqlCommand.Parameters.AddWithValue("@pid", cart.ProductID);
                            sqlCommand.Parameters.AddWithValue("@quantity", cart.Quantity); 
                            if (sqlCommand.ExecuteNonQuery() == 0)
                            {
                                throw new Exception("Failed to insert the product");
                            }
                        }
                        sqlTransaction.Commit();
                        Growl.Success("Delivery has been added successfully!");
                        mainWindow?.UpdateUI();
                        Helpers.CloseDialog(Closebtn);
                    } catch
                    {
                        sqlTransaction.Rollback();
                    }
                } else
                {
                    throw new Exception("Failed to insert the header.");
                }

            } catch
            {
                Growl.Warning("An error occured while performing the action.");
            } finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        private void AdditionalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
