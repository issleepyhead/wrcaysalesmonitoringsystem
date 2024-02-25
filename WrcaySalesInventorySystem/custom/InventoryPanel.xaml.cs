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

namespace WrcaySalesInventorySystem.custom
{
    /// <summary>
    /// Interaction logic for InventoryPanel.xaml
    /// </summary>
    public partial class InventoryPanel : UserControl, IUpdatePanels
    {
        public InventoryPanel()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            //throw new NotImplementedException();
        }
    }
}
