using HandyControl.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Classs.Interface;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.Dialogs
{
    public partial class UserDialog : UserControl
    {
        private readonly ViewModelUser _vmUser = new();
        private readonly MainWindow? mainWindow;
        public UserDialog(ViewModelUser? vmUser = null)
        {
            InitializeComponent();
            if (vmUser != null)
            {
                _vmUser = vmUser;
                SaveButton.Content = "Update";
            }
            else
            {
                DeleteButton.Visibility = Visibility.Collapsed;
            }
            mainWindow = Application.Current?.Windows.OfType<MainWindow>().FirstOrDefault();
            DataContext = _vmUser;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_vmUser.Exists())
            {
                Growl.Info("Account already exists!");
                return;
            }

            IDataExecutor? command;
            _vmUser.Password = PasswordTextBox.Password;
            if (_vmUser.UserID != null)
            {
                command = new UpdateCommand(_vmUser);
            }
            else
            {
                command = new AddCommand(_vmUser);
            }


            if (command != null && command.Execute())
            {
                Growl.Success((_vmUser?.UserID != null) ? "Account has been updated." : "Account has been added.");
                Helpers.CloseDialog(Closebtn);
            }
            else
                Growl.Error((_vmUser?.UserID != null) ? "Failed updating the account." : "Failed adding the account.");
            mainWindow?.UpdateUI();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            IDataExecutor command = new DeleteCommand(_vmUser);
            if (command.Execute())
            {
                Growl.Success("Account has been deleted.");
                Helpers.CloseDialog(Closebtn);
            }
            else
            {
                Growl.Warning("Failed deleting account.");
            }
            mainWindow?.UpdateUI();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new BaseConnection().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblroles", conn);
            DataTable dataTable = new();
            SqlDataAdapter adapter = new(cmd);
            adapter.Fill(dataTable);
            RoleComboBox.ItemsSource = dataTable.DefaultView;
            RoleComboBox.DisplayMemberPath = "role_name";
            RoleComboBox.SelectedValuePath = "id";
            RoleComboBox.SelectedIndex = 0;
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleComboBox.SelectedIndex != -1)
                _vmUser.RoleID = RoleComboBox.SelectedValue.ToString();
        }
    }
}
