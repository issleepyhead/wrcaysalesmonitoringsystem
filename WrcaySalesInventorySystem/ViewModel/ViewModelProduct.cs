using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Models;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelProduct : ViewModelBase, IDataCommand
    {
        private readonly ApplicationDatabaseContext _databaseContext = new();
        private readonly Tblproduct _tblproduct;
        public ViewModelProduct(Tblproduct tblproduct)
        {
            _tblproduct = tblproduct;
        }

        public string? ProductName
        {
            get => _tblproduct.ProductName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _tblproduct.ProductName = value;
                }
                Changed("ProductName");
            }
        }

        public string? ProductDescription
        {
            get => _tblproduct.ProductDescription;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _tblproduct.ProductDescription = value;
                Changed("ProductDescription");
            }
        }

        public string? ProductPrice
        {
            get => _tblproduct.ProductCost < 0 ? null : _tblproduct.ProductPrice.ToString();
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _tblproduct.ProductPrice = double.Parse(value);
                    Changed("ProductPrice");
                }
            }
        }

        public string? ProductCost
        {
            get => _tblproduct.ProductCost < 0 ? null : _tblproduct.ProductCost.ToString();
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _tblproduct.ProductCost = double.Parse(value);
                    Changed("ProductCost");
                }
            }
        }

        public int ProductID
        {
            get => _tblproduct.Id;
            set
            {
                _tblproduct.Id = value;
            }
        }

        public int? CategoryID
        {
            get => _tblproduct.CategoryId;
            set
            {
                _tblproduct.CategoryId = value;
            }
        }

        public string? CategoryName
        {
            get => _tblproduct?.Category?.CategoryName;
            set
            {
                if (_tblproduct != null && _tblproduct?.Category != null)
                {
                    _tblproduct.Category.CategoryName = value;
                }
            }
        }

        public Tblcategory? Category
        {
            get
            {
                if (_tblproduct != null && _tblproduct?.Category != null)
                {
                    return _tblproduct.Category;
                }
                return null;
            }

            set
            {
                if (_tblproduct != null && _tblproduct?.Category != null)
                {
                    _tblproduct.Category = value;
                }
            }
        }

        public bool Add()
        {
            try
            {
                _databaseContext.Tblproducts.Add(_tblproduct);
                int res = _databaseContext.SaveChanges();
                return res > 0;

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
                _databaseContext.Tblproducts.Remove(_tblproduct);
                int res = _databaseContext.SaveChanges();
                return res > 0;
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
                var res = _databaseContext.Tblproducts.ToArray();
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i].ProductName == ProductName)
                    {
                        if (ProductID != 0 && ProductID != res[i].Id)
                            return true;
                        return true;
                    }
                }
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
                _databaseContext.Tblproducts.Update(_tblproduct);
                int res = _databaseContext.SaveChanges();
                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
