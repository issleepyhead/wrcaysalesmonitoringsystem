using HandyControl.Controls;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.custom;
using WrcaySalesInventorySystem.Models;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.Dialogs
{
    /// <summary>
    /// Interaction logic for CategoryDialog.xaml
    /// </summary>
    public partial class CategoryDialog : UserControl
    {
        readonly ViewModelCategory _vmCategory;
        readonly ApplicationDatabaseContext databaseContext = new();
        readonly Tblcategory category = new();
        readonly CategoryPanel _categPanel;
        public CategoryDialog(CategoryPanel categPanel, ViewModelCategory? vmCategory = null)
        {
            InitializeComponent();
            if (vmCategory == null)
                _vmCategory = new ViewModelCategory(category);
            else
                _vmCategory = vmCategory;
            _categPanel = categPanel;
            if (vmCategory != null)
            {
                SaveCategoryButton.Content = "Update";
            }
            DataContext = _vmCategory;
        }

        private void SaveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CategoryNameTextBox.Text.Trim()))
            {
                if (_vmCategory.Exists())
                {
                    Growl.Success("Category already exists.");
                    return;
                }
                if (_vmCategory.CategoryID != 0)
                {
                    if(_vmCategory.Update())
                    {
                        Growl.Success("Category has been updated successfully.");
                        Helpers.CloseDialog(Closebtn);
                    } else
                    {
                        Growl.Warning("Failed updating category.");
                    }
                } else
                { 
                    if (_vmCategory.Add())
                    {    
                        Growl.Success("Category has been added successfully.");
                        Helpers.CloseDialog(Closebtn);
                    }
                    else
                    {
                        Growl.Warning("Failed adding new category.");
                    }
                }
                CategoryNameError.Text = null;
            } else
            {
                CategoryNameError.Text = "Please provide a name for category";
            }
            _categPanel.UpdateTable();
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_vmCategory.Delete())
            {
                Growl.Success("Category has been deleted succesfully.");
                Helpers.CloseDialog(Closebtn);
            } else
            {
                Growl.Warning("Failed deleting category.");
            }
            _categPanel.UpdateTable();
        }
    }
}