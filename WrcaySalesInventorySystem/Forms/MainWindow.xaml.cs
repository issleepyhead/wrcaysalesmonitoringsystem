using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools.Command;
using WrcaySalesInventorySystem.Class;
using WrcaySalesInventorySystem.custom;

namespace WrcaySalesInventorySystem
{
    public partial class MainWindow : HandyControl.Controls.Window, System.Windows.Markup.IComponentConnector, IUpdatePanels
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ClosePanels()
        {
            UserControl[] panels = { AccountPanel, ProductsPanel, AuditTralPanel,
                CategoriesPanel, SupplierPanel, TransactionPanel,   InventoryPanel, 
                DeliveryPanel, POSPanel
            };

            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Visibility = Visibility.Collapsed;
            }
        }

        public void SelectedPanel(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                if (sender is SideMenuItem item)
                {
                    ClosePanels();
                    TextBlock headerText = (TextBlock)item.Header;
                    switch(headerText.Text.ToLower())
                    {
                        case "dashboard":
                            break;
                        case "pos":
                            POSPanel.Visibility = Visibility.Visible;
                            break;
                        case "products":
                            ProductsPanel.Visibility = Visibility.Visible;
                            break;
                        case "categories":
                            CategoriesPanel.Visibility = Visibility.Visible;
                            break;
                        case "suppliers":
                            SupplierPanel.Visibility = Visibility.Visible;
                            break;
                        case "stocks":
                            InventoryPanel.Visibility = Visibility.Visible;
                            break;
                        case "delivery":
                            DeliveryPanel.Visibility = Visibility.Visible;
                            break;
                        case "transaction report":
                            TransactionPanel.Visibility = Visibility.Visible;
                            break;
                        case "expenses":
                            break;
                        case "users":
                            AccountPanel.Visibility = Visibility.Visible;
                            break;
                        case "database":
                            break;
                    }
                }
            }
        }


        public void UpdateUI()
        {
            IUpdatePanels[] panels = { AccountPanel, ProductsPanel, AuditTralPanel,
                CategoriesPanel, SupplierPanel, TransactionPanel,   InventoryPanel,
                DeliveryPanel, POSPanel
            };

            foreach (IUpdatePanels panel in panels)
                panel.UpdateUI();

        }
    }
}
