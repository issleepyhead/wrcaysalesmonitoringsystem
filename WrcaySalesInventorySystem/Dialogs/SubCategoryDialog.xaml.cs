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
using InputType = WrcaySalesInventorySystem.Class.InputType;

namespace WrcaySalesInventorySystem.Dialogs
{
    /// <summary>
    /// Interaction logic for SubCategoryDialog.xaml
    /// </summary>
    public partial class SubCategoryDialog : UserControl
    {
        public SubCategoryDialog()
        {
            InitializeComponent();
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
    }
}
