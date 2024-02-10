using System.Windows;

namespace WrcaySalesInventorySystem
{
    public partial class MainWindow : HandyControl.Controls.Window, System.Windows.Markup.IComponentConnector
    {
        //private readonly ApplicationDatabaseContext _databaseContext;
        public MainWindow(/*ApplicationDatabaseContext databaseContext*/)
        {
            //_databaseContext = databaseContext;
            InitializeComponent();
        }
    }
}
