using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelDeliveryCart : ViewModelBase
    {
        private string? _productID;
        private string? _quantity;
        private string? _cost;
        private string? _price;
        private string? _total;
        private string? _productName;
        private string? _stocksAvailable;
        public string? _stocks = null;

        public string? ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                Changed("ProductName");
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

        public string? Price
        {
            get => _price;
            set
            {
                _price = value;
                Changed("Price");
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

        public string? Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                Changed("Quantity");
            }
        }

        public string? Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                Changed("Cost");
            }
        }

        public string?  Total
        {
            get => _total;
            set
            {
                _total = value;
                Changed("Total");
            }
        }

    }
}
