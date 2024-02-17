using System;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.Models;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelCategory : ViewModelBase, IDataCommand
    {
        private Tblcategory  _category;
        private ApplicationDatabaseContext _databaseContext;

        public ViewModelCategory(Tblcategory category, ApplicationDatabaseContext databaseContext)
        {
            _category = category;
            _databaseContext = databaseContext;
        }

        public string? CategoryName
        {
            get => _category.CategoryName;
            set
            {
                _category.CategoryName = value;
                Changed("CategoryName");
            }
        }

        public string? CategoryDescription
        {
            get => _category.CategoryDescription;
            set
            {
                _category.CategoryDescription = value;
                Changed("CategoryDescription");
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

        public async Task<bool> Add()
        {
            try
            {
                await _databaseContext.Tblcategories.AddAsync(_category);
                int res = await _databaseContext.SaveChangesAsync();
                return res > 0;

            } catch(Exception)
            {
                return false;
            }
            
        }

        public async Task<bool> Delete()
        {
            try
            {
                _databaseContext.Tblcategories.Remove(_category);
                int res = await _databaseContext.SaveChangesAsync();
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
                var res = _databaseContext.Tblcategories.Find(_category);
                return res is null;
            } catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> IsValid()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update()
        {
            try
            {
                _databaseContext.Tblcategories.Update(_category);
                int res = await _databaseContext.SaveChangesAsync();
                return res > 0;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
