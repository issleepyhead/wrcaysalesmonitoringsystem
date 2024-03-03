using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelSubCategory : ViewModelBase, IDataCommand
    {
        private SqlConnection? _sqlConnection;
        private SqlCommand? _sqlCommand;
        private string? _categoryName;
        private string? _categoryDescription;
        private int _parentCategoryID;
        private string? _parentName;
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

        public int ParentCategoryID
        {
            get => _parentCategoryID;
            set
            {
                _parentCategoryID = value;
                Changed("ParentCategoryID");
            }
        }

        public string? ParentName
        {
            get => _parentName;
            set
            {
                _parentName = value;
                Changed("ParentName");
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
        public string? CategoryDescription
        {
            get => _categoryDescription;
            set
            {
                _categoryDescription = value;
                Changed("CategoryDescription");
            }
        }
        public int CategoryID
        {
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
                    "InsertSubcategoryProcedure @category_name, @category_description, @parent_id, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@category_name", CategoryName);
                _sqlCommand.Parameters.AddWithValue("@parent_id", ParentCategoryID);
                _sqlCommand.Parameters.AddWithValue("@category_description", CategoryDescription == null ? DBNull.Value : CategoryDescription);
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
                    "DeleteSubcategoryProcedure @category_id, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@category_id", CategoryID);
                _sqlCommand.Parameters.AddWithValue("@user_id", Settings.Default.userID);
                return _sqlCommand.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            } finally
            {
                _sqlConnection?.Dispose();
            }
        }

        public bool Exists()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                    "SELECT COUNT(*) FROM tblcategories WHERE category_name = @category_name AND parent_id = @parent_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@category_name", CategoryName);
                _sqlCommand.Parameters.AddWithValue("@parent_id", ParentCategoryID);
                return (int)_sqlCommand.ExecuteScalar() > 0;
            }
            catch
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
                    "UpdateSubcategoryProcedure @id,  @category_name, @category_description, @pid, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@id", CategoryID);
                _sqlCommand.Parameters.AddWithValue("@category_name", CategoryName);
                _sqlCommand.Parameters.AddWithValue("@pid", ParentCategoryID);
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

        public static List<ViewModelSubCategory> getAll(bool haystack = false)
        { 

            SqlConnection _sqlConnection = new BaseConnection().getConnection();
            List<ViewModelSubCategory> vmData = new List<ViewModelSubCategory>();
            SqlCommand _sqlCommand;
            if (haystack)
            {
                _sqlCommand = new(
                    "SELECT * FROM viewcategories",
                    _sqlConnection
                );
                SqlDataAdapter adaptera = new(_sqlCommand);
                DataTable dataa = new();
                adaptera.Fill(dataa);
                if (dataa != null)
                {
                    for (int i = 0; i < dataa.Rows.Count; i++)
                    {
                        ViewModelSubCategory viewModel = new();
                        viewModel.CategoryID = (int)dataa.Rows[i][0];
                        viewModel.CategoryName = dataa.Rows[i][1].ToString();
                        vmData.Add(viewModel);
                    }
                }
                return vmData;
            }
            else
            {
                _sqlCommand = new(
                    "SELECT * FROM viewtblsubcategories",
                    _sqlConnection
                );
                
            }
            SqlDataAdapter adapter = new(_sqlCommand);
            DataTable data = new();
            adapter.Fill(data);

            if (data != null)
            {
                for (int i = 0; i < data?.Rows.Count; i++)
                {
                    ViewModelSubCategory vmCat = new();
                    if (data != null)
                    {
                        vmCat.CategoryID = (int)data.Rows[i][0];
                        vmCat.ParentCategoryID = (int)data.Rows[i][1];
                        vmCat.CategoryName = data.Rows[i][2].ToString();
                        vmCat.CategoryDescription = data.Rows[i][3].ToString();
                        vmCat.ParentName = data.Rows[i][4].ToString();
                        vmCat.CreatedBy = data.Rows[i][5].ToString();
                        vmCat.UpdatedBy = data.Rows[i][6].ToString();
                        string x = data.Rows[i][7].ToString() ?? "";
                        string y = data.Rows[i][8].ToString() ?? "";
                        vmCat.DateAdded = DateTime.Parse(x).ToShortDateString();
                        vmCat.DateUpdated = DateTime.Parse(y).ToShortDateString();
                    }
                    vmData.Add(vmCat);
                }
            }
            return vmData;
        }
    }
}
