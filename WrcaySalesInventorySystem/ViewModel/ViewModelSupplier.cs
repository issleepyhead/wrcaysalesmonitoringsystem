using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.ViewModel 
{
    public class ViewModelSupplier : ViewModelBase, IDataCommand
    {
        private SqlConnection _sqlConnection = new BaseConnection().getConnection();
        private SqlCommand? _sqlCommand;
        private int _supplierID;
        private string? _supplierName;
        private string? _firstName;
        private string? _lastName;
        private string? _city;
        private string? _supplierCountry;
        private string? _supplierAddress;
        private string? _supplierContact;
        private int _updatedBy;
        private int _createdBy;
        private DateTime _dateAdded;
        private DateTime _dateUpdated;
        private string? _createdUser;
        private string? _updatedUser;

        public string? SupplierName
        {
            get => _supplierName;
            set
            {
                _supplierName = value;
                Changed("SupplierName");
            }
        }

        public int SupplierID
        {
            get => _supplierID;
            set
            {
                _supplierID = value;
                Changed("SupplierIDN");
            }
        }

        public string? SupplierLastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                Changed("SupplierLastName");
            }
        }

        public string? SupplierFirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                Changed("SupplierFirstName");
            }
        }

        public string? SupplierCity
        {
            get => _city;
            set
            {
                _city = value;
                Changed("SupplierCity");
            }
        }

        public string? SupplierCountry
        {
            get => _supplierCountry;
            set
            {
                _supplierCountry = value;
                Changed("SupplierCountry");
            }
        }

        public string? SupplierAddress
        {
            get => _supplierAddress;
            set
            {
                _supplierAddress = value;
                Changed("SupplierAddress");
            }
        }

        public string? SupplierPhone
        {
            get => _supplierContact;
            set
            {
                _supplierContact = value;
                Changed("SupplierPhone");
            }
        }

        public int UpdatedBy
        {
            get => _updatedBy;
            set
            {
                _updatedBy = value;
                Changed("UpdatedBy");
            }
        }

        public int CreatedBy
        {
            get => _createdBy;
            set
            {
                _createdBy = value;
                Changed("CreatedBy");
            }
        }

        public DateTime DateAdded
        {
            get => _dateAdded;
            set
            {
                _dateAdded = value;
                Changed("DateAdded");
            }
        }

        public DateTime DateUpdated
        {
            get => _dateUpdated;
            set
            {
                _dateUpdated = value;
                Changed("DateUpdated");
            }
        }

        public string? CreatedUser
        {
            get => _createdUser;
            set
            {
                _createdUser = value;
                Changed("CreatedUser");
            }
        }

        public string? UpdatedUser
        {
            get => _updatedUser;
            set
            {
                _updatedUser = value;
                Changed("UpdatedUser");
            }
        }

        public bool Add()
        {
            try
            {
                _sqlCommand = new SqlCommand(
                    "InsertSupplierProcedure @supplier_name, @first_name, @last_name, " +
                    "@city, @country, @address, @contact, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@supplier_name", SupplierName);
                _sqlCommand.Parameters.AddWithValue("@first_name", SupplierFirstName);
                _sqlCommand.Parameters.AddWithValue("@last_name", SupplierLastName);
                _sqlCommand.Parameters.AddWithValue("@city", SupplierCity);
                _sqlCommand.Parameters.AddWithValue("@country", SupplierCountry);
                _sqlCommand.Parameters.AddWithValue("@address", SupplierAddress);
                _sqlCommand.Parameters.AddWithValue("@contact", SupplierPhone);
                _sqlCommand.Parameters.AddWithValue("@user_id", 22);
                return _sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Exists()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }

        public bool Update()
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
