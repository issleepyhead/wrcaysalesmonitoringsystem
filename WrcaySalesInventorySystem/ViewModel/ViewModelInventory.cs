using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelInventory : ViewModelBase, IDataCommand
    {
        private string? _id;
        private string? _productID;
        private string? _productName;
        private string? _stocksAvailable;
        private string? _stocksSold;
        private string? _defective;
        private string? _lastUpdated;
        private string? _productPrice;
        private string? _productCost;

        public string? ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                Changed("ProductName");
            }
        }

        public string? ProductPrice
        {
            get => _productPrice;
            set
            {
                _productPrice = value;
                Changed("ProductPrice");
            }
        }

        public string? ProductCost
        {
            get => _productCost;
            set
            {
                _productCost = value;
                Changed("ProductCost");
            }
        }

        public string? ProductID
        {
            get => _productID;
            set
            {
                _productID = value;
                Changed("ProductID");
            }
        }

        public string? StocksAvailable
        {
            get => _stocksAvailable;
            set
            {
                _stocksAvailable = value;
                Changed("StocksAvailable");
            }
        }

        public string? StocksSold
        {
            get => _stocksSold;
            set
            {
                _stocksSold = value;
                Changed("StocksSold");
            }
        }

        public string? Defective
        {
            get => _defective;
            set
            {
                _defective = value;
                Changed("Defective");
            }
        }

        public string? LastUpdated
        {
            get => _lastUpdated;
            set
            {
                _lastUpdated = value;
                Changed("LastUpdated");
            }
        }

        public string? ID
        {
            get => _id;
            set
            {
                _id = value;
                Changed("ID");
            }
        }

        public bool Add()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Exists()
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public static ObservableCollection<ViewModelInventory> getAll()
        {
            ObservableCollection<ViewModelInventory> vmData = new();
            SqlConnection _sqlConnection = new(Settings.Default.wrcaydbConnectionString);
            try
            {
                SqlCommand _sqlCommand = new SqlCommand(
                    "SELECT * FROM viewtblinventory",
                    _sqlConnection
                );
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    //for (int i = 0; i < data?.Rows.Count; i++)
                    //{
                        
                        foreach (DataRow row in data.Rows)
                        {
                        ViewModelInventory vmCat = new();
                        vmCat.ID = row["id"].ToString();
                            vmCat.ProductID = row["product_id"].ToString();
                            vmCat.ProductName = row["product_name"].ToString();
                            vmCat.StocksAvailable= row["stocks"].ToString();
                            vmCat.StocksSold = row["sold"].ToString();
                            vmCat.Defective = row["defective"].ToString();
                            vmCat.ProductPrice = row["product_price"].ToString();
                            string x = row["last_updated"].ToString() ?? "";
                            vmCat.LastUpdated = DateTime.Parse(x).ToShortDateString();
                            vmData.Add(vmCat);
                    }

                    //}
                }
                return vmData;
            }
            catch
            {
                return new ObservableCollection<ViewModelInventory>();
            }
            finally
            {
                _sqlConnection?.Dispose();
            }
        }
    }
}
