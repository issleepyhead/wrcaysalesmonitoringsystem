using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelUser : ViewModelBase, IDataCommand
    {
        private SqlConnection? _sqlConnection;
        private SqlCommand? _sqlCommand;
        private string? _userID;
        private string? _roleID;
        private string? _roleName;
        private string? _userFirst;
        private string? _userLast;
        private string? _userAddress;
        private string? _userContact;
        private string? _userUserName;
        private string? _userPassword;
        private string? _userDate;

        public string? RoleID
        {
            get => _roleID;
            set
            {
                _roleID = value;
                Changed("RoleID");
            }
        }

        public string? RoleName
        {
            get => _roleName;
            set
            {
                _roleName = value;
                Changed("RoleName");
            }
        }

        public string? UserID
        {
            get => _userID;
            set
            {
                _userID = value;
                Changed("UserID");
            }
        }

        public string? FirstName
        {
            get => _userFirst;
            set
            {
                _userFirst = value;
                Changed("UserID");
            }
        }

        public string? LastName
        {
            get => _userLast;
            set
            { 
                _userLast = value;
                Changed("UserID");
            }
        }

        public string? Address
        {
            get => _userAddress;
            set
            {
                _userAddress = value;
                Changed("UserID");
            }
        }

        public string? Contact
        {
            get => _userContact;
            set
            {
                _userContact = value;
                Changed("UserID");
            }
        }

        public string? UserName
        {
            get => _userUserName;
            set
            {
                _userUserName = value;
                Changed("UserName");
            }
        }

        public string? Password
        {
            get => _userPassword;
            set
            {
                _userPassword = value;
                Changed("UserPassword");
            }
        }

        public string? DateCreated
        {
            get => _userDate;
            set
            {
                _userDate = value;
                Changed("DateCreated");
            }
        }

        public bool Exists()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                if (UserID != null)
                {
                    _sqlCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM tblusers WHERE username = @username",
                        _sqlConnection
                     );
                    _sqlCommand.Parameters.AddWithValue("@username", UserName);
                }
                else
                {
                    _sqlCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM tblusers WHERE username = @username AND id = @user_id",
                        _sqlConnection
                    );
                    _sqlCommand.Parameters.AddWithValue("@username", UserName);
                    _sqlCommand.Parameters.AddWithValue("@user_id", UserID);
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

        bool IDataCommand.Add()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "InsertAccountProcedure @role_id, @first_name, @last_name, @address, @contact, @username, @password, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@role_id", RoleID);
                _sqlCommand.Parameters.AddWithValue("@first_name", FirstName);
                _sqlCommand.Parameters.AddWithValue("@last_name", LastName);
                _sqlCommand.Parameters.AddWithValue("@address", Address);
                _sqlCommand.Parameters.AddWithValue("@contact", Contact);
                _sqlCommand.Parameters.AddWithValue("@username", UserName);
                _sqlCommand.Parameters.AddWithValue("@password", Password);
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

        bool IDataCommand.Delete()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "DeleteAccountProcedure @account_id, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@account_id", UserID);
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

        bool IDataCommand.IsValid()
        {
            throw new NotImplementedException();
        }

        bool IDataCommand.Update()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "UpdateAccountProcedure @role_id, @first_name, @last_name, @address, @contact, @username, @password, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@role_id", RoleID);
                _sqlCommand.Parameters.AddWithValue("@first_name", FirstName);
                _sqlCommand.Parameters.AddWithValue("@last_name", LastName);
                _sqlCommand.Parameters.AddWithValue("@address", Address);
                _sqlCommand.Parameters.AddWithValue("@contact", Contact);
                _sqlCommand.Parameters.AddWithValue("@username", UserName);
                _sqlCommand.Parameters.AddWithValue("@password", Password);
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

        public static List<ViewModelUser> getAll()
        {
            List<ViewModelUser> vmData = new();
            SqlConnection _sqlConnection = new(Settings.Default.wrcaydbConnectionString);
            try
            {
                SqlCommand _sqlCommand = new SqlCommand(
                    "SELECT * FROM viewtblusers",
                    _sqlConnection
                );
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    for (int i = 0; i < data?.Rows.Count; i++)
                    {
                        ViewModelUser vmCat = new();
                        foreach (DataRow row in data.Rows)
                        {
                            vmCat.UserID = row["ID"].ToString();
                            vmCat.FirstName = row["first_name"].ToString();
                            vmCat.LastName = row["last_name"].ToString();
                            vmCat.RoleName = row["ROLE"].ToString();
                            vmCat.Address = row["ADDRESS"].ToString();
                            vmCat.Contact = row["CONTACT"].ToString();
                            vmCat.UserName = row["USERNAME"].ToString();
                            vmCat.Password = row["PASSWORD"].ToString();
                            vmCat.DateCreated = row["DATE_CREATED"].ToString();
                            vmCat.RoleID = row["RoleID"].ToString();
                        }
                        vmData.Add(vmCat);
                    }
                }
                return vmData;
            }
            catch
            {
                return new List<ViewModelUser>();
            }
            finally
            {
                _sqlConnection?.Dispose();
            }

        }
    }
}
