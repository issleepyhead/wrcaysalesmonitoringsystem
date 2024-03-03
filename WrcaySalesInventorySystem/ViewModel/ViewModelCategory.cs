using WrcaySalesInventorySystem.Classs.Interface;
using System.Data.SqlClient;
using System.Data;
using WrcaySalesInventorySystem.Class;
using Microsoft.VisualBasic;
using WrcaySalesInventorySystem.Properties;
using System;
using System.Windows.Documents;
using System.Collections.Generic;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelCategory : ViewModelBase , IDataCommand
    {
        private SqlConnection? _sqlConnection;
        private SqlCommand? _sqlCommand;
        private string? _categoryName;
        private string? _categoryDescription;
        private string? _dateAdded;
        private string? _dateUpdated;
        private string? _createdBy;
        private string? _updatedBy;
        private int _updatedID;
        private int _createdID;
        private int _categoryID;

        public int CreatedID
        {
            get => _createdID;
            set
            {
                _createdID = value;
                Changed("CreatedID");
            }
        }

        public int UpdatedID
        {
            get => _updatedID;
            set
            {
                _updatedID = value;
                Changed("UpdatedID");
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

        public string? CreatedBy
        {
            get => _createdBy;
            set
            {
                _createdBy = value;
                Changed("CreatedBy");
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

        public string? DateAdded
        {
            get => _dateAdded;
            set
            {
                _dateAdded = value;
                Changed("DateAdded");
            }
        }

        public string? CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                Changed("CategoryName");
            }
        }
        public string? CategoryDescription { 
            get => _categoryDescription;
            set
            {
                _categoryDescription = value;
                Changed("CategoryDescription");
            }
        }
        public int CategoryID { 
            get => _categoryID;
            set
            {
                _categoryID = value;
                Changed("CategoryID");
            }
        }

        public bool Add()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "InsertCategoryProcedure @category_name, @category_description, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@category_name", CategoryName);
                _sqlCommand.Parameters.AddWithValue("@category_description", CategoryDescription == null? DBNull.Value :CategoryDescription);
                _sqlCommand.Parameters.AddWithValue("@user_id", 22);
                return _sqlCommand.ExecuteNonQuery() > 0;
            } catch (Exception)
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
                    "DeleteCategoryProcedure @category_id, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@category_id", CategoryID);
                _sqlCommand.Parameters.AddWithValue("@user_id", Settings.Default.userID);
                return _sqlCommand.ExecuteNonQuery() > 0;
            } catch
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
                if (CategoryID == 0)
                {
                    _sqlCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM tblcategories WHERE category_name = @category_name",
                        _sqlConnection
                     );
                    _sqlCommand.Parameters.AddWithValue("@category_name", CategoryName);
                } else
                {
                    _sqlCommand = new SqlCommand(
                        "SELECT COUNT(*) FROM tblcategories WHERE category_name = @category_name AND id = @category_id",
                        _sqlConnection
                    );
                    _sqlCommand.Parameters.AddWithValue("@category_name", CategoryName);
                    _sqlCommand.Parameters.AddWithValue("@category_id", CategoryID);
                }
                return (int)_sqlCommand.ExecuteScalar() > 0;
            } catch
            {
                return false;
            } finally
            {
                _sqlConnection?.Dispose();
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
                    "UpdateCategoryProcedure @id,  @category_name, @category_description, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@id", CategoryID);
                _sqlCommand.Parameters.AddWithValue("@category_name", CategoryName);
                _sqlCommand.Parameters.AddWithValue("@category_description", CategoryDescription);
                _sqlCommand.Parameters.AddWithValue("@user_id", Settings.Default.userID);
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

        public static List<ViewModelCategory> getAll()
        {
            List<ViewModelCategory> vmData = new();
            SqlConnection _sqlConnection = new(Settings.Default.wrcaydbConnectionString);
            try
            {
                SqlCommand _sqlCommand = new SqlCommand(
                    "SELECT * FROM viewtblcategories",
                    _sqlConnection
                );
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    for (int i = 0; i < data?.Rows.Count; i++)
                    {
                        ViewModelCategory vmCat = new();
                        if (data != null)
                        {
                            vmCat.CategoryID = (int)data.Rows[i][0];
                            vmCat.CategoryName = data.Rows[i][1].ToString();
                            vmCat.CategoryDescription = data.Rows[i][2].ToString();
                            vmCat.CreatedBy = data.Rows[i][3].ToString();
                            vmCat.UpdatedBy = data.Rows[i][4].ToString();
                            string x = data.Rows[i][5].ToString() ?? "";
                            string y = data.Rows[i][6].ToString() ?? "";
                            vmCat.DateAdded = DateTime.Parse(x).ToShortDateString();
                            vmCat.DateUpdated = DateTime.Parse(y).ToShortDateString();
                        }
                        vmData.Add(vmCat);
                    }
                }
                return vmData;
            } catch
            {
                return new List<ViewModelCategory>();
            } finally
            {
                _sqlConnection?.Dispose();
            }
            
        }
    }
}
