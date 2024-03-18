using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Class;
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
        private string? _statusName;

        public string? SupplierID
        {
            get => _supplierID;
            set
            {
                _supplierID = value;
                Changed("SupplierID");
            }
        }

        public string? StatusName
        {
            get => _statusName;
            set
            {
                _statusName = value;
                Changed("StatusName");
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

        public static ObservableCollection<ViewModelDelivery> getAll()
        {
            ObservableCollection<ViewModelDelivery> vmData = new();
            SqlConnection _sqlConnection = new BaseConnection().getConnection();
            try
            {
                SqlCommand _sqlCommand = new(
                    "SELECT * FROM viewtbldeliveries",
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
                            ViewModelDelivery vmCat = new();
                            vmCat.DeliveryID = row["id"].ToString();
                            vmCat.SupplierID = row["supplier_id"].ToString();
                            vmCat.SupplierName = row["supplier_name"].ToString();
                            vmCat.CreatedBy = row["created_by"].ToString();
                            vmCat.TotalCost = row["total_Cost"].ToString();
                            vmCat.ReferenceNumber = row["reference_number"].ToString();
                            vmCat.StatusName = row["status_name"].ToString();
                            string x = row["delivery_date"].ToString() ?? "";
                            vmCat.DeliveryDate = DateTime.Parse(x).ToShortDateString();
                            vmData.Add(vmCat);
                    }
                        
                    //}
                }
                return vmData;
            }
            catch
            {
                return new ObservableCollection<ViewModelDelivery>();
            }
            finally
            {
                _sqlConnection?.Dispose();
            }
        }
    }
}
