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
        private string? _productID;
        private string? _productName;
        private string? _productDescription;
        private string? _productPrice;
        private string? _productCost;
        private string? _categoryID;
        private string? _categoryName;
        private string? _createdBy;
        private string? _updatedBy;
        private string? _dateAdded;
        private string? _dateUpdated;
        private string? _createdUser;
        private string? _updatedUser;
        private string? _sku;
        private string? _supplierID;

        public string? ProductUnit
        {
            get => _sku;
            set
            {
                _sku = value;
                Changed("ProductUnit");
            }
        }

        public string? SupplierID
        {
            get => _supplierID;
            set
            {
                _supplierID = value;
                Changed("SupplierID");
            }
        }

        public string? CreatedBy { get => _createdBy; set => _createdBy = value; }
        public string? UpdatedBy { get => _updatedBy; set=> _updatedBy = value; }

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

        public string? ProductID {
            get => _productID;
            set
            {
                _productID = value;
                Changed("ProductID");
            }
        }

        public string? CategoryID
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
                    "@product_price, @product_cost, @sku, @supplier_id, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@product_name", ProductName);
                _sqlCommand.Parameters.AddWithValue("@product_price", ProductPrice);
                _sqlCommand.Parameters.AddWithValue("@supplier_id", string.IsNullOrEmpty(SupplierID) ? DBNull.Value : SupplierID);
                _sqlCommand.Parameters.AddWithValue("@product_cost", ProductCost);
                _sqlCommand.Parameters.AddWithValue("@sku", ProductUnit);
                _sqlCommand.Parameters.AddWithValue("@product_category", string.IsNullOrEmpty(CategoryID) ? DBNull.Value : CategoryID);
                _sqlCommand.Parameters.AddWithValue("@product_description", string.IsNullOrEmpty(ProductDescription) ? DBNull.Value : ProductDescription);
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
                    "@product_price, @product_cost, @supplier_id, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@product_name", ProductName);
                _sqlCommand.Parameters.AddWithValue("@supplier_id", string.IsNullOrEmpty(SupplierID) ? DBNull.Value : SupplierID);
                _sqlCommand.Parameters.AddWithValue("@product_id", ProductID);
                _sqlCommand.Parameters.AddWithValue("@product_price", ProductPrice);
                _sqlCommand.Parameters.AddWithValue("@product_cost", ProductCost);
                _sqlCommand.Parameters.AddWithValue("@product_category", string.IsNullOrEmpty(CategoryID) ? DBNull.Value : CategoryID);
                _sqlCommand.Parameters.AddWithValue("@product_description", string.IsNullOrEmpty(ProductDescription) ? DBNull.Value : ProductDescription);
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
            SqlConnection _sqlConnection = new BaseConnection().getConnection();
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
                    foreach(DataRow row in data.Rows)
                    {
                        ViewModelProduct vmCat = new();
                        if (data != null)
                        {
                            vmCat.ProductID = row["id"].ToString();
                            vmCat.CategoryID = row["category_id"].ToString();
                            vmCat.CategoryName = row["category_name"].ToString();
                            vmCat.ProductName = row["product_name"].ToString();
                            vmCat.ProductDescription = row["product_description"].ToString();
                            vmCat.ProductPrice = row["product_price"].ToString();
                            vmCat.ProductCost = row["product_cost"].ToString();
                            vmCat.ProductUnit = row["sku"].ToString();
                            vmCat.CreatedUser = row["created_by"].ToString();
                            vmCat.UpdatedUser = row["updated_by"].ToString();
                            string x = row["date_added"].ToString() ?? "";
                            string y = row["date_updated"].ToString() ?? "";
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
