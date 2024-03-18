using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WrcaySalesInventorySystem.ViewModel;

namespace WrcaySalesInventorySystem.custom
{
    /// <summary>
    /// Interaction logic for InventoryPanel.xaml
    /// </summary>
    public partial class InventoryPanel : UserControl, IUpdatePanels
    {
        private ObservableCollection<ViewModelInventory>? _data;
        public InventoryPanel()
        {
            InitializeComponent();
            UpdateUI();
        }

        public void UpdateUI()
        {
            _data = ViewModelInventory.getAll();

            InventoryRecordsDataGrid.ItemsSource = _data.Take(30);
            Helpers.PaginationConfig(_data.Count, PaginationRecords);
        }

        private void PaginationRecords_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            InventoryRecordsDataGrid.ItemsSource = _data?.Skip((e.Info - 1) * 30).Take(30);
        }
    }
}
