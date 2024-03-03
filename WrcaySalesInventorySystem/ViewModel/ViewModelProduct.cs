using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelProduct : ViewModelBase, IDataCommand
    {
        private SqlConnection? _sqlConnection;
        private SqlCommand? _sqlCommand;
        private int _productID;
        private string? _productName;
        private string? _productDescription;
        private string? _productPrice;
        private string? _productCost;
        private int _categoryID;
        private string? _categoryName;
        private int _createdBy;
        private int _updatedBy;
        private string? _dateAdded;
        private string? _dateUpdated;
        private string? _createdUser;
        private string? _updatedUser;
        private int _sku;

        public int ProductUnit
        {
            get => _sku;
            set
            {
                _sku = value;
                Changed("ProductUnit");
            }
        }

        public int CreatedBy { get => _createdBy; set => _createdBy = value; }
        public int UpdatedBy { get => _updatedBy; set=> _updatedBy = value; }

        public string? UpdatedUser
        {
            get => _updatedUser;
            set
            {
                _updatedUser = value;
                Changed("UpdatedUser");
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

        public string? CreatedUser
        {
            get => _createdUser;
            set
            {
                _createdUser = value;
                Changed("CreatedUser");
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

        public string? ProductName
        {
            get => _productName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _productName = value;
                }
                Changed("ProductName");
            }
        }

        public string? ProductDescription
        {
            get => _productDescription;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _productDescription = value;
                Changed("ProductDescription");
            }
        }

        public string? ProductPrice
        {
            get => _productPrice;
            set
            {
                _productPrice = value;
                Changed("ProductPrice");
            }
        }

        public string? ProductCost
        {
            get => _productCost;
            set
            {
                _productCost = value;
                Changed("ProductCost");
            }
        }

        public int ProductID {
            get => _productID;
            set
            {
                _productID = value;
                Changed("ProductID");
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
                    "InsertProductProcedure @product_category, @product_name, @product_description, " +
                    "@product_price, @product_cost, @sku, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@product_name", ProductName);
                _sqlCommand.Parameters.AddWithValue("@product_price", ProductPrice);
                _sqlCommand.Parameters.AddWithValue("@product_cost", ProductCost);
                _sqlCommand.Parameters.AddWithValue("@sku", ProductUnit);
                _sqlCommand.Parameters.AddWithValue("@product_category", CategoryID == 0 ? DBNull.Value : CategoryID);
                _sqlCommand.Parameters.AddWithValue("@product_description", ProductDescription == null ? DBNull.Value : ProductDescription);
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
                    "DeleteProductProcedure @product_id, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@product_id", ProductID);
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

        public bool Exists()
        {
            try
            {
                _sqlConnection = new BaseConnection().getConnection();
                _sqlCommand = new SqlCommand(
                       "SELECT COUNT(*) FROM tblproducts WHERE product_name = @product_name",
                       _sqlConnection
                   );
                _sqlCommand.Parameters.AddWithValue("@product_name", ProductName);
                return (int)_sqlCommand.ExecuteScalar() > 0;
            }
            catch (Exception)
            {
                return false;
            } finally
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
                    "UpdateProductProcedure @product_id, @product_category, @product_name, @product_description, " +
                    "@product_price, @product_cost, @product_subcategory, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@product_name", ProductName);
                _sqlCommand.Parameters.AddWithValue("@product_id", ProductID);
                _sqlCommand.Parameters.AddWithValue("@product_price", ProductPrice);
                _sqlCommand.Parameters.AddWithValue("@product_cost", ProductCost);
                _sqlCommand.Parameters.AddWithValue("@product_category", CategoryID == 0 ? DBNull.Value : CategoryID);
                _sqlCommand.Parameters.AddWithValue("@product_description", ProductDescription == null ? DBNull.Value : ProductDescription);
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

        public static List<ViewModelProduct> getAll()
        {
            List<ViewModelProduct> vmData = new();
            SqlConnection _sqlConnection = _sqlConnection = new BaseConnection().getConnection();
            try
            {
                SqlCommand _sqlCommand = new SqlCommand(
                    "SELECT * FROM viewtblproducts",
                    _sqlConnection
                );
                SqlDataAdapter adapter = new(_sqlCommand);
                DataTable data = new();
                adapter.Fill(data);
                if (data != null)
                {
                    for (int i = 0; i < data?.Rows.Count; i++)
                    {
                        ViewModelProduct vmCat = new();
                        if (data != null)
                        {
                            vmCat.ProductID = (int)data.Rows[i][0];
                            vmCat.CategoryID = (int)data.Rows[i][1];
                            vmCat.CategoryName = data.Rows[i][2].ToString();
                            vmCat.ProductName = data.Rows[i][3].ToString();
                            vmCat.ProductDescription = data.Rows[i][4].ToString();
                            vmCat.ProductPrice = data.Rows[i][5].ToString();
                            vmCat.ProductCost = data.Rows[i][6].ToString();
                            vmCat.ProductUnit = (int)data.Rows[i][7];
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
                return new List<ViewModelProduct>();
            }
            finally
            {
                _sqlConnection?.Dispose();
            }
        }
    }
}
