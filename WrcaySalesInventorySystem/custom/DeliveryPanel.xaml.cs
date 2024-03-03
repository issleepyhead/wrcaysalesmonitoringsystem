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

namespace WrcaySalesInventorySystem.custom
{
    /// <summary>
    /// Interaction logic for DeliveryPanel.xaml
    /// </summary>
    public partial class DeliveryPanel : UserControl, IUpdatePanels
    {
        public DeliveryPanel()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            //throw new NotImplementedException();
        }

        private void DeliveryAddDeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog.Show(new DeliveryCartDialog());
        }
    }
}
