using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelVAT : ViewModelBase, IDataCommand
    {
        private SqlConnection? _sqlConnection;
        private SqlCommand? _sqlCommand;
        private int _vatID;
        private string? _vatName;
        private string? _vatValue;
        private string? _createdBy;
        private string? _updatedBy;
        private string? _dateUpdated;
        private string? _dateAdded;

        public string? CreatedBy
        {
            get => _createdBy;
            set
            {
                _createdBy = value;
                Changed("CreatedBy");
            }
        }

        public string? UpdatedBy
        {
            get => _updatedBy;
            set
            {
                _updatedBy = value;
                Changed("UpdatedBy");
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

        public int VatID
        {
            get => _vatID;
            set
            {
                _vatID = value;
                Changed("VatID");
            }
        }

        public string? VatName
        {
            get => _vatName;
            set
            {
                _vatName = value;
                Changed("VatName");
            }
        }

        public string? VatValue
        {
            get => _vatValue;
            set
            {
                _vatValue = value;
                Changed("VatValue");
            }
        }

        public bool Add()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "InsertVatProcedure @vat_name, @vat_value, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@vat_name", VatName);
                _sqlCommand.Parameters.AddWithValue("@vat_value", VatValue);
                _sqlCommand.Parameters.AddWithValue("@user_id", 22);
                return _sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
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
                    "DeleteVatProcedure @vat_id, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@vat_id", VatID);
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
                if (VatID == 0)
                {
                    _sqlCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM tblvat WHERE vat_name = @vat_name",
                        _sqlConnection
                     );
                    _sqlCommand.Parameters.AddWithValue("@vat_name", VatName);
                }
                else
                {
                    _sqlCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM tblvat WHERE vat_name = @vat_name AND id = @vat_id",
                        _sqlConnection
                    );
                    _sqlCommand.Parameters.AddWithValue("@vat_name", VatName);
                    _sqlCommand.Parameters.AddWithValue("@vat_id", VatID);
                }
                return (int)_sqlCommand.ExecuteScalar() > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                _sqlConnection?.Dispose();
            }
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "UpdateVatProcedure @id,  @vat_name, @vat_value, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@id", VatID);
                _sqlCommand.Parameters.AddWithValue("@vat_name", VatName);
                _sqlCommand.Parameters.AddWithValue("@vat_value", VatValue);
                _sqlCommand.Parameters.AddWithValue("@user_id", Settings.Default.userID);
                return _sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _sqlConnection?.Dispose();
            }
        }

        public static List<ViewModelVAT> getAll()
        {
            List<ViewModelVAT> vmData = new();
            SqlConnection _sqlConnection =new  BaseConnection().getConnection();
            try
            {
                SqlCommand _sqlCommand = new SqlCommand(
                    "SELECT * FROM tblvatview",
                    _sqlConnection
                );
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    for (int i = 0; i < data?.Rows.Count; i++)
                    {
                        ViewModelVAT vmCat = new();
                        if (data != null)
                        {
                            vmCat.VatID = (int)data.Rows[i][0];
                            vmCat.VatName = data.Rows[i][1].ToString();
                            vmCat.VatValue = data.Rows[i][2].ToString();
                            vmCat.CreatedBy = data.Rows[i][3].ToString();
                            vmCat.UpdatedBy = data.Rows[i][4].ToString();
                            string x = data.Rows[i][5].ToString() ?? "";
                            string t = data.Rows[i][6].ToString() ?? "";
                            vmCat.DateAdded = DateTime.Parse(x).ToShortDateString();
                            vmCat.DateUpdated = DateTime.Parse(t).ToShortDateString();
                        }
                        vmData.Add(vmCat);
                    }
                }
                return vmData;
            }
            catch
            {
                return new List<ViewModelVAT>();
            }
            finally
            {
                _sqlConnection?.Dispose();
            }

        }
    }
}
