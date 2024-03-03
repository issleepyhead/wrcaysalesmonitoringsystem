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
using WrcaySalesInventorySystem.Dialogs;
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
    public partial class VATPanel : UserControl, IUpdatePanels
    {
        private List<ViewModelVAT>? _data;
        public VATPanel()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new VATDialog());
        }

        public void UpdateUI()
        {
            _data = ViewModelVAT.getAll();

            VATDataGridView.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count, Pagination);
        }

        private void Pagination_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            VATDataGridView.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }

        private void VATDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VATDataGridView.SelectedItems.Count > 0)
            {
                ViewModelVAT vmCateg = (ViewModelVAT)VATDataGridView.SelectedItem;
                Dialog.Show(new VATDialog(vmCateg));
            }
            VATDataGridView.SelectedItems.Clear();
        }
    }
}
