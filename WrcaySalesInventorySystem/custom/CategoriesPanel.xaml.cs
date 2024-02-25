using System.Windows.Controls;
using WrcaySalesInventorySystem.Class;

namespace WrcaySalesInventorySystem.custom
{
    /// <summary>
    /// Interaction logic for MaintenancePanel.xaml
    /// </summary>
    public partial class CategoriesPanel : UserControl, IUpdatePanels
    {
        public CategoriesPanel()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            CategoryPanel.UpdateUI();
            SubCategoryPanel.UpdateUI();
        }
    }
}
