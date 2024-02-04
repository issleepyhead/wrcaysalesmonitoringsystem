using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrcaySalesInventorySystem.Models;

namespace WrcaySalesInventorySystem.ViewModel
{
    internal class ViewModelCategory : ViewModelBase
    {
        private Category _category = new();


        public string? CategoryName {
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
            get => _category.CategoryId;
            set
            {
                _category.CategoryId = value;
                Changed("CategoryID");
            }
        }

        
    }
}
