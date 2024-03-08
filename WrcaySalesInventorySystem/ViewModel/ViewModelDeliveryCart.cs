using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelDeliveryCart : ViewModelBase
    {
        private int _productID;
        private string? _quantity;
        private double _price;
        private double _cost;
        private double _total;
        private string? _productName;

        public string? ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                Changed("ProductName");
            }
        }

        public int ProductID
        {
            get => _productID;
            set
            {
                _productID = value;
                Changed("ProductID");
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

        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                Changed("Price");
            }
        }

        public double Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                Changed("Cost");
            }
        }

        public double  Total
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
