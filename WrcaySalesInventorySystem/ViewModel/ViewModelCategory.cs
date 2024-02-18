using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Models;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelCategory : ViewModelBase , IDataCommand
    {
       private readonly Tblcategory  _category;
       private readonly ApplicationDatabaseContext _databaseContext = new();

        public ViewModelCategory(Tblcategory category)
        {
            _category = category;
        }

        public string? CategoryName
        {
            get => _category.CategoryName;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _category.CategoryName = value;
                    Changed("CategoryName");
                }
            }
        }

        public string? CategoryDescription
        {
            get {
                if(string.IsNullOrEmpty(_category.CategoryDescription))
                    return "None";
                else
                    return _category.CategoryDescription;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _category.CategoryDescription = value;
                    Changed("CategoryDescription");
                }
            }
        }

        public int CategoryID
        {
            get => _category.Id;
            set
            {
                _category.Id = value;
                Changed("CategoryID");
            }
        }

        public bool Add()
        {
            try
            {
                _databaseContext.Tblcategories.Add(_category);
                int res = _databaseContext.SaveChanges();
                return res > 0;

            } catch(Exception)
            {
                return false;
            }
            
        }

        public bool Delete()
        {
            try
            {
                _databaseContext.Tblcategories.Remove(_category);
                int res = _databaseContext.SaveChanges();
                return res > 0;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool Exists()
        {
            try
            {
                var res = _databaseContext.Tblcategories.ToArray();
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i].CategoryName == CategoryName)
                    {
                        if (CategoryID != 0 && CategoryID != res[i].Id)
                            return true;
                        return true;
                    }
                }
                return false;
            } catch (Exception)
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
                _databaseContext.Tblcategories.Update(_category);
                int res = _databaseContext.SaveChanges();
                return res > 0;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
