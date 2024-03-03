using HandyControl.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup.Primitives;
using System.Windows.Media;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.custom;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.Dialogs
{
    /// <summary>
    /// Interaction logic for CategoryDialog.xaml
    /// </summary>
    public partial class CategoryDialog : UserControl
    {
        private readonly ViewModelCategory _vmCategory = new();
        private readonly MainWindow? mainWindow;
        public CategoryDialog(ViewModelCategory? vmCategory = null)
        {
            InitializeComponent();
            if (vmCategory != null)
            { 
                _vmCategory = vmCategory;
                SaveCategoryButton.Content = "Update";
            } else
            {
                DeleteCategoryButton.Visibility = Visibility.Collapsed;
            }
            mainWindow = Application.Current?.Windows.OfType<MainWindow>().FirstOrDefault();
            DataContext = _vmCategory;
        }

        private void SaveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if(!Helpers.Check(CategoryNameTextBox, CategoryNameError, InputType.STRING_INPUT, "Please provide a valid category name"))
            {
                return;
            }
            if (_vmCategory.Exists())
            {
                Growl.Info("Category already exists!");
                return;
            }

            IDataExecutor? command;
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
                Growl.Success((_vmCategory?.CategoryID != 0) ? "Category has been updated." : "Category has been added.");
                Helpers.CloseDialog(Closebtn);
            }
            else
                Growl.Error((_vmCategory?.CategoryID != 0) ? "Failed updating the category." : "Failed adding the category.");
            mainWindow?.UpdateUI();
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_vmCategory.Delete())
            {
                Growl.Success("Category has been deleted.");
                Helpers.CloseDialog(Closebtn);
            }
            else
            {
                Growl.Warning("Failed deleting category.");
            }
            mainWindow?.UpdateUI();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!ValidationCheck.ValidateInput(CategoryNameTextBox.Text, InputType.STRING_INPUT))
            {
                CategoryNameTextBox.BorderBrush = Brushes.Red;
                CategoryNameError.Visibility = Visibility.Visible;
                CategoryNameError.Text = "Please provide a valid category name";
            } else
            {
                CategoryNameTextBox.BorderBrush = new BrushConverter().ConvertFromString("#FFE0E0E0") as Brush;
                CategoryNameError.Visibility = Visibility.Collapsed;
                CategoryNameError.Text = null;
            }
        }
    }
}