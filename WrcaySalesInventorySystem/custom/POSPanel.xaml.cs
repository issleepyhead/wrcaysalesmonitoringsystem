using System;
using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;

namespace WrcaySalesInventorySystem.custom
{
    public partial class POSPanel : UserControl, IUpdatePanels
    {
        public POSPanel()
        {
            InitializeComponent();
        }

        void IUpdatePanels.UpdateUI()
        {
            //throw new NotImplementedException();
        }
    }
}
