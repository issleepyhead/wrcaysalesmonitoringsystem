using HandyControl.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
    public partial class AccountPanel : UserControl, IUpdatePanels
    {
        private List<ViewModelUser>? _data;
        public AccountPanel()
        {
            InitializeComponent();
            UpdateUI();
        }

        public void UpdateUI()
        {
            _data = ViewModelUser.getAll();

            AccountsDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count, Pagination);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new UserDialog());
        }

        private void AccountsDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccountsDataGridView.SelectedItems.Count > 0)
            {
                ViewModelUser vmCateg = (ViewModelUser)AccountsDataGridView.SelectedItem;
                Dialog.Show(new UserDialog(vmCateg));
            }
            AccountsDataGridView.SelectedItems.Clear();
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            AccountsDataGridView.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }
    }
}
