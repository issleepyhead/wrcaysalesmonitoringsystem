using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelDelivery : ViewModelBase, IDataCommand
    {
        private string? _deliveryID;
        private string? _supplierID;
        private string? _referenceNo;
        private string? _supplierName;
        private string? _totalCost;
        private string? _createdBy;
        private string? _deliveryDate;
        private string? _dateAdded;

        public string? SupplierID
        {
            get => _supplierID;
            set
            {
                _supplierID = value;
                Changed("SupplierID");
            }
        }

        public string? DeliveryID
        {
            get => _deliveryID;
            set
            {
                _deliveryID = value;
                Changed("DeliveryID");
            }
        }

        public string? ReferenceNumber
        {
            get => _referenceNo;
            set
            {
                _referenceNo = value;
                Changed("ReferenceNumber");
            }
        }

        public string? SupplierName
        {
            get => _supplierName;
            set
            {
                _supplierName = value;
                Changed("SupplierName");
            }
        }

        public string? TotalCost
        {
            get => _totalCost;
            set
            {
                _totalCost = value;
                Changed("TotalCost");
            }
        }

        public string? CreatedBy
        {
            get => _createdBy;
            set
            {
                _createdBy = value;
                Changed("CreatedBy");
            }
        }

        public string? DeliveryDate
        {
            get => _deliveryDate;
            set
            {
                _deliveryDate = value;
                Changed("DeliveryDate");
            }
        }

        public string? DateAdded
        {
            get => _dateAdded;
            set
            {
                _dateAdded = value;
                Changed("DateAdded");
            }
        }

        public bool Add()
        {
            return false;
        }

        public bool Delete()
        {
            return true;
        }

        public bool Exists()
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            return false;
        }

        public bool Update()
        {
            return true;
        }
    }
}
