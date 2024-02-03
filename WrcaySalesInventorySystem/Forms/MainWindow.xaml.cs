using System.Windows;
using WrcaySalesInventorySystem.Data;

namespace WrcaySalesInventorySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationDatabaseContext _databaseContext;
        public MainWindow(ApplicationDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            InitializeComponent();
        }
    }
}
