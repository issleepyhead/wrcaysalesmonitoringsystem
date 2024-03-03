using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.custom;
using WrcaySalesInventorySystem.ViewModel;
using InputType = WrcaySalesInventorySystem.Class.InputType;

namespace WrcaySalesInventorySystem.Dialogs
{
    public partial class SubCategoryDialog : UserControl
    {
        private readonly MainWindow? mainWindow;
        private ViewModelSubCategory _vmCategory;
        public SubCategoryDialog(ViewModelSubCategory? subcategory = null)
        {
            InitializeComponent();
            mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault<MainWindow>();
            if (subcategory != null)
            {
                SaveCategoryButton.Content = "Update";
                _vmCategory = subcategory;
            } else
            {
                DeleteCategoryButton.Visibility = Visibility.Collapsed;
                _vmCategory = new();
            }
            DataContext = _vmCategory;
        }

        private void SubCategoryNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!ValidationCheck.ValidateInput(SubCategoryNameTextBox.Text, InputType.STRING_INPUT))
            {
                SubCategoryNameTextBox.BorderBrush = Brushes.Red;
                SubCategoryNameError.Visibility = Visibility.Visible;
                SubCategoryNameError.Text = "Please provide a valid category name";
            }
            else
            {
                SubCategoryNameTextBox.BorderBrush = new BrushConverter().ConvertFromString("#FFE0E0E0") as Brush;
                SubCategoryNameError.Visibility = Visibility.Collapsed;
                SubCategoryNameError.Text = null;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CategoryCheckCombobox.ItemsSource = ViewModelCategory.getAll();
            CategoryCheckCombobox.DisplayMemberPath = "CategoryName";
            CategoryCheckCombobox.SelectedValuePath = "CategoryID";
            CategoryCheckCombobox.SelectedIndex = 0;
        }

        private void SaveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryCheckCombobox.SelectedIndex == -1)
            {
                CategoryCheckCombobox_SelectionChanged(CategoryCheckCombobox.DataContext, null);
                return;
            }

            if (!Helpers.Check(SubCategoryNameTextBox, SubCategoryNameError, InputType.STRING_INPUT, "Please provide a valid name."))
            {
                return;
            }
                IDataExecutor? command = null;

            if (_vmCategory.Exists())
            {
                Growl.Info("Sub category already exists!");
                return;
            }

            if (_vmCategory.CategoryID != 0)
            {
                command = new UpdateCommand(_vmCategory);
            }
            else
            {
                command = new AddCommand(_vmCategory);
            }


            if (command != null && command.Execute())
            {
                Growl.Success((_vmCategory?.CategoryID != 0) ? "Sub category has been updated successfully." : "Sub category has been added successfully.");
                Helpers.CloseDialog(Closebtn);
            }
            else
                Growl.Error((_vmCategory?.CategoryID != 0) ? "Failed updating the sub category." : "Failed adding the sub category.");
            mainWindow?.UpdateUI();
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_vmCategory.Delete())
            {
                Growl.Success("Sub category has been deleted successfully.");
                Helpers.CloseDialog(Closebtn);
            }
            else
            {
                Growl.Warning("Failed deleting sub category.");
            }
            mainWindow?.UpdateUI();
        }

        private void CategoryCheckCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryCheckCombobox.SelectedIndex == -1 )
            {
                CategoryError.Visibility = Visibility.Visible;
                CategoryError.Text = "Please provide parent category";
            } else
            {
                CategoryError.Visibility = Visibility.Collapsed;
                CategoryError.Text = null;
                _vmCategory.ParentCategoryID = (int)CategoryCheckCombobox.SelectedValue;
            }
        }
    }
}
