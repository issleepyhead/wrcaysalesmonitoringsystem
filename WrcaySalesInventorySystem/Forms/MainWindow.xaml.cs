using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools.Command;

namespace WrcaySalesInventorySystem
{
    public partial class MainWindow : HandyControl.Controls.Window, System.Windows.Markup.IComponentConnector
    {

        public MainWindow(/*ApplicationDatabaseContext databaseContext*/)
        {
            //_databaseContext = databaseContext;
            InitializeComponent();
        }

        public void ClosePanels()
        {
            UserControl[] panels = { AccountPanel, ProductsPanel, AuditTralPanel,
                CategoryPanel, SupplierPanel, TransactionPanel,   InventoryPanel, 
                DeliveryPanel
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
                            Growl.Info("Dashboard");
                            break;
                        case "pos":
                            Growl.Info("POS");
                            break;
                        case "products":
                            Growl.Info("Products");
                            ProductsPanel.Visibility = Visibility.Visible;
                            break;
                        case "categories":
                            Growl.Info("Categories");
                            CategoryPanel.Visibility = Visibility.Visible;
                            break;
                        case "sub categories":
                            Growl.Info("Sub Categories");
                            break;
                        case "suppliers":
                            Growl.Info("Suppliers");
                            SupplierPanel.Visibility = Visibility.Visible;
                            break;
                        case "vat":
                            Growl.Info("VAT");
                            break;
                        case "inventory":
                            Growl.Info("Inventory");
                            InventoryPanel.Visibility = Visibility.Visible;
                            break;
                        case "stocks":
                            Growl.Info("Stocks");
                            break;
                        case "delivery":
                            Growl.Info("Delivery");
                            break;
                        case "transaction report":
                            Growl.Info("Transaction Reports");
                            break;
                        case "stock in report":
                            Growl.Info("Stock In Report");
                            break;
                        case "expenses":
                            Growl.Info("Expenses");
                            break;
                        case "users":
                            Growl.Info("Users");
                            AccountPanel.Visibility = Visibility.Visible;
                            break;
                        case "database":
                            Growl.Info("Database");
                            break;
                    }
                }
            }
        }
    }
}
