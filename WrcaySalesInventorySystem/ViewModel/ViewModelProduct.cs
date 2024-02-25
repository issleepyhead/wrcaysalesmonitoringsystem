using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelProduct : ViewModelBase, IDataCommand
    {
        private SqlConnection _sqlConnection = new BaseConnection().getConnection();
        private SqlCommand? _sqlCommand;
        private int _productID;
        private string? _productName;
        private string? _productDescription;
        private double _productPrice;
        private double _productCost;
        private int _categoryID;
        private int _createdBy;
        private int _updatedBy;
        private DateTime _dateAdded;
        private DateTime _dateUpdated;
        private string? _createdUser;
        private string? _updatedUser;

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

        public string? CreatedUser
        {
            get => _createdUser;
            set
            {
                _createdUser = value;
                Changed("CreatedUser");
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

        public DateTime DateAdded
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

        public double ProductPrice
        {
            get => _productPrice;
            set
            {
                _productPrice = value;
                Changed("ProductPrice");
            }
        }

        public double ProductCost
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
                _sqlCommand = new SqlCommand(
                    "InsertProductProcedure @product_category, @product_name, @product_description, " +
                    "@product_price, @product_cost, @user_id",
                    _sqlConnection
                );
                _sqlCommand.Parameters.AddWithValue("@product_name", ProductName);
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
            }
        }

        public bool Delete()
        {
            try
            {
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
            }
        }

        public bool Exists()
        {
            try
            {
                return false;
            }
            catch (Exception)
            {
                return false;
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
            }
        }
    }
}
