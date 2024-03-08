using HandyControl.Controls;
using System.Windows;
using System.Windows.Controls;
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
