using HandyControl.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.custom;
using WrcaySalesInventorySystem.ViewModel;
using InputType = WrcaySalesInventorySystem.Class.InputType;
using TextBox = HandyControl.Controls.TextBox;

namespace WrcaySalesInventorySystem.Dialogs
{
    public partial class SupplierDialog : UserControl
    {
        private readonly ViewModelSupplier _vmModel;
        private readonly MainWindow? mainWindow;
        public SupplierDialog(ViewModelSupplier? vmModel = null)
        {
            InitializeComponent();
            if (vmModel != null)
            {
                _vmModel = vmModel;
                SaveButton.Content = "Update";
            }
            else
            {
                DeleteButton.Visibility = Visibility.Collapsed;
                _vmModel = new();
            }
            mainWindow = Application.Current?.Windows.OfType<MainWindow>().FirstOrDefault();
            DataContext = _vmModel;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender.Equals(SupplierContactTextBox))
            {
                Helpers.Check((TextBox)sender, ContactError, InputType.PHONE_INPUT, "Please provide a valid mobile number.");
            } else if (sender.Equals(SupplierFirstNameTextBox))
            {
                Helpers.Check((TextBox)sender, FirstNameError, InputType.STRING_INPUT, "Please provide a first name.");
            } else if (sender.Equals(SupplierLastNameTextBox))
            {
                Helpers.Check((TextBox)sender, LastError, InputType.STRING_INPUT, "Please provide a last name.");
            } else if (sender.Equals(SupplierAddressTextBox))
            {
                Helpers.Check((TextBox)sender, AddressError, InputType.STRING_INPUT, "Please provide an address.");
            } else
            {
                Helpers.Check((TextBox)sender, CompanyError, InputType.STRING_INPUT, "Please provide a name.");
            }

        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Helpers.Check(SupplierContactTextBox, ContactError, InputType.PHONE_INPUT, "Please provide a valid mobile number.") ||
                !Helpers.Check(SupplierFirstNameTextBox, FirstNameError, InputType.STRING_INPUT, "Please provide a first name.") ||
                !Helpers.Check(SupplierLastNameTextBox, LastError, InputType.STRING_INPUT, "Please provide a last name.") ||
                    !Helpers.Check(SupplierAddressTextBox, AddressError, InputType.STRING_INPUT, "Please provide an address.") ||
                !Helpers.Check(SupplierCompanyTextBox, CompanyError, InputType.STRING_INPUT, "Please provide a name."))
            {
                return;
            }

            if (_vmModel.Exists())
            {
                Growl.Info("Category already exists!");
                return;
            }

            IDataExecutor? command;
            if (_vmModel.SupplierID != 0)
            {
                command = new UpdateCommand(_vmModel);
            }
            else
            {
                command = new AddCommand(_vmModel);
            }


            if (command != null && command.Execute())
            {
                Growl.Success((_vmModel?.SupplierID!= 0) ? "Supplier has been updated." : "Supplier has been added.");
                Helpers.CloseDialog(Closebtn);
            }
            else
                Growl.Error((_vmModel?.SupplierID != 0) ? "Failed updating the supplier." : "Failed adding the supplier.");
            mainWindow?.UpdateUI();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_vmModel.Delete())
            {
                Growl.Success("Supplier has been deleted.");
                Helpers.CloseDialog(Closebtn);
            }
            else
            {
                Growl.Warning("Failed deleting supplier.");
            }
            mainWindow?.UpdateUI();
        }
    }
}
