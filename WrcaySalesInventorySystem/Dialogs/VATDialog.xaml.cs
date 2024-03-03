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
using WrcaySalesInventorySystem.ViewModel;
using InputType = WrcaySalesInventorySystem.Class.InputType;

namespace WrcaySalesInventorySystem.Dialogs
{
    public partial class VATDialog : UserControl
    {
        private readonly ViewModelVAT _vmVat = new();
        private readonly MainWindow? mainWindow;
        public VATDialog(ViewModelVAT? vmVat = null)
        {
            InitializeComponent();
            if (vmVat != null)
            {
                _vmVat = vmVat;
                SaveCategoryButton.Content = "Update";
            }
            else
            {
                DeleteCategoryButton.Visibility = Visibility.Collapsed;
            }
            mainWindow = Application.Current?.Windows.OfType<MainWindow>().FirstOrDefault();
            DataContext = _vmVat;
        }

        private void SaveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if(!Helpers.Check(VATNameTextBox, VATNameError, InputType.STRING_INPUT, "Please provide a valid name.") ||
               !Helpers.Check(VATValueTextBox, VATValueError, InputType.NUMERIC_INPUT, "Please provide a valid vat value."))
            {
                return;
            }
            if (_vmVat.Exists())
            {
                Growl.Info("VAT already exists!");
                return;
            }

            IDataExecutor? command;
            if (_vmVat.VatID != 0)
            {
                command = new UpdateCommand(_vmVat);
            }
            else
            {
                command = new AddCommand(_vmVat);
            }


            if (command != null && command.Execute())
            {
                Growl.Success((_vmVat?.VatID != 0) ? "VAT has been updated." : "VAT has been added.");
                Helpers.CloseDialog(Closebtn);
            }
            else
                Growl.Error((_vmVat?.VatID != 0) ? "Failed updating the VAT." : "Failed adding the VAT.");
            mainWindow?.UpdateUI();
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_vmVat.Delete())
            {
                Growl.Success("VAT has been deleted.");
                Helpers.CloseDialog(Closebtn);
            }
            else
            {
                Growl.Warning("Failed deleting VAT.");
            }
            mainWindow?.UpdateUI();
        }
    }
}
