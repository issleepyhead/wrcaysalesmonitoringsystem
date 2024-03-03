using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem.ViewModel 
{
    public class ViewModelSupplier : ViewModelBase, IDataCommand
    {
        private SqlConnection? _sqlConnection;
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
        private string? _dateAdded;
        private string? _dateUpdated;
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

        public string? DateAdded
        {
            get => _dateAdded;
            set
            {
                _dateAdded = value;
                Changed("DateAdded");
            }
        }

        public string? DateUpdated
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
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "InsertSupplierProcedure @supplier_name, @first_name, @last_name, " +
                    "@city, @country, @address, @contact, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@supplier_name", SupplierName);
                _sqlCommand.Parameters.AddWithValue("@first_name", SupplierFirstName);
                _sqlCommand.Parameters.AddWithValue("@last_name", SupplierLastName);
                _sqlCommand.Parameters.AddWithValue("@city", SupplierCity == null ? DBNull.Value : SupplierCity);
                _sqlCommand.Parameters.AddWithValue("@country", SupplierCountry == null ? DBNull.Value : SupplierCountry);
                _sqlCommand.Parameters.AddWithValue("@address", SupplierAddress);
                _sqlCommand.Parameters.AddWithValue("@contact", SupplierPhone);
                _sqlCommand.Parameters.AddWithValue("@user_id", 22);
                return _sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            } finally
            {
                _sqlConnection?.Dispose();
            }

        }

        public bool Delete()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "DeleteSupplierProcedure @supplier_id, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@supplier_id", SupplierID);
                _sqlCommand.Parameters.AddWithValue("@user_id", Settings.Default.userID);
                return _sqlCommand.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                _sqlCommand?.Dispose();
            }
        }

        public bool Exists()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                if (SupplierID == 0)
                {
                    _sqlCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM tblsuppliers WHERE supplier_name = @supplier_name",
                        _sqlConnection
                     );
                    _sqlCommand.Parameters.AddWithValue("@supplier_name", SupplierName);
                }
                else
                {
                    _sqlCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM tblsuppliers WHERE supplier_name = @supplier_name AND id = @supplier_id",
                        _sqlConnection
                    );
                    _sqlCommand.Parameters.AddWithValue("@supplier_name", SupplierName);
                    _sqlCommand.Parameters.AddWithValue("@supplier_id", SupplierID);
                }
                return (int)_sqlCommand.ExecuteScalar() > 0;
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
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "UpdateSupplierProcedure @id, @supplier_name, @first_name, @last_name, " +
                    "@city, @country, @address, @contact, @user_id",
                    _sqlConnection
                );

                _sqlCommand.Parameters.AddWithValue("@id", SupplierID);
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

        public static List<ViewModelSupplier> getAll()
        {
            List<ViewModelSupplier> vmData = new();
            SqlConnection _sqlConnection = new BaseConnection().getConnection();
            try
            {
                SqlCommand _sqlCommand = new(
                    "SELECT * FROM viewtblsuppliers",
                    _sqlConnection
                );
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    for (int i = 0; i < data?.Rows.Count; i++)
                    {
                        ViewModelSupplier vmCat = new();
                        if (data != null)
                        {
                            vmCat.SupplierID = (int)data.Rows[i][0];
                            vmCat.SupplierName = data.Rows[i][1].ToString();
                            vmCat.SupplierFirstName = data.Rows[i][2].ToString();
                            vmCat.SupplierLastName = data.Rows[i][3].ToString();
                            vmCat.SupplierCity = data.Rows[i][4].ToString();
                            vmCat.SupplierCountry = data.Rows[i][5].ToString();
                            vmCat.SupplierAddress = data.Rows[i][6].ToString();
                            vmCat.SupplierPhone = data.Rows[i][7].ToString();
                            vmCat.CreatedUser = data.Rows[i][8].ToString();
                            vmCat.UpdatedUser = data.Rows[i][9].ToString();
                            string x = data.Rows[i][10].ToString() ?? "";
                            string y = data.Rows[i][11].ToString() ?? "";
                            vmCat.DateAdded = DateTime.Parse(x).ToShortDateString();
                            vmCat.DateUpdated = DateTime.Parse(y).ToShortDateString();
                        }
                        vmData.Add(vmCat);
                    }
                }
                return vmData;
            }
            catch
            {
                return new List<ViewModelSupplier>();
            }
            finally
            {
                _sqlConnection?.Dispose();
            }
        }
    }
}
