using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;

namespace WrcaySalesInventorySystem.custom
{
    /// <summary>
    /// Interaction logic for TransactionPanel.xaml
    /// </summary>
    public partial class TransactionPanel : UserControl, IUpdatePanels
    {
        public TransactionPanel()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            //throw new NotImplementedException();
        }
    }
}
