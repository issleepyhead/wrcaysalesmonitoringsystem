using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Models;

namespace WrcaySalesInventorySystem.ViewModel 
{
    public class ViewModelSupplier : ViewModelBase, IDataCommand
    {
        private readonly Tblsupplier _supplier;
        private readonly ApplicationDatabaseContext _databaseContext;

        public ViewModelSupplier(Tblsupplier supplier, ApplicationDatabaseContext databaseContext)
        {
            _supplier = supplier;
            _databaseContext = databaseContext;
        }

        public string? SupplierName
        {
            get => _supplier.SupplierName;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _supplier.SupplierName = value;
                    Changed("supplierName");
                }
            }
        }

        public string? SupplierAddress
        {
            get => _supplier.SupplierAddress;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _supplier.SupplierAddress = value;
                    Changed("SupplierAddress");
                }
            }
        }

        public string? SupplierContact
        {
            get => _supplier.SupplierContact;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _supplier.SupplierContact = value;
                    Changed("SupplierContact");
                }
            }
        }

        public int SupplierID
        {
            get => _supplier.Id;
            set
            {
                _supplier.Id = value;
                Changed("SupplierID");
            }
        }

        public bool Add()
        {
            try
            {
                _databaseContext.Tblsuppliers.Add(_supplier);
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
                _databaseContext.Tblsuppliers.Remove(_supplier);
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
                var res = _databaseContext.Tblcategories.Find(_supplier);
                return res is null;
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
                _databaseContext.Tblsuppliers.Update(_supplier);
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
