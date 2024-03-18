using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows.Threading;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.ViewModel;
using WrcaySalesInventorySystem.Custom;
using WrcaySalesInventorySystem.Dialogs;
using HandyControl.Controls;

namespace WrcaySalesInventorySystem.custom
{
    public partial class POSPanel : UserControl, IUpdatePanels
    {
        private DispatcherTimer timer = new();
        public ObservableCollection<ViewModelDeliveryCart> _data = new();
        public POSPanel()
        {
            InitializeComponent();
            try
            {
                timer.Tick += new EventHandler(UpdateDate);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
            } catch
            {

            }
        }

        void IUpdatePanels.UpdateUI()
        {
            //throw new NotImplementedException();
        }

        private void UpdateDate(object? sender, EventArgs e)
        {
            DateHolder.Text = DateTime.Now.ToLongDateString();
        }

        private void ProductSearch_SearchStarted(object sender, HandyControl.Data.FunctionEventArgs<string> e)
        {
            SqlConnection conn = new BaseConnection().getConnection();
            SqlCommand cmd = new("SELECT p.id, p.product_name, p.product_price, t.stocks FROM tblinventory t JOIN tblproducts p ON t.product_id = p.id WHERE p.product_name LIKE @product_name", conn);
            cmd.Parameters.AddWithValue("@product_name", ProductSearch.Text);
            DataTable dataTable = new();
            SqlDataAdapter adapter = new(cmd);
            adapter.Fill(dataTable);

            ObservableCollection<ViewModelDeliveryCart> source = new ObservableCollection<ViewModelDeliveryCart>();
            foreach (DataRow row in dataTable.Rows)
            {
                ViewModelDeliveryCart vm = new();
                vm.Price = row["product_price"].ToString();
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
                ProductCartList.Children.Add(new POSProductEntity(this, cart));
            }
        }


        private void AddDelivery_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            Dialog.Show(new POSDialog(this));
        }
    }
}