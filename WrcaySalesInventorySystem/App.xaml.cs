using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
//using WrcaySalesInventorySystem.Data;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            //services.AddDbContext<ApplicationDatabaseContext>(options => {
            //    options.UseSqlServer(Settings.Default.wrcaydbConnectionString);
            //});
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(Object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
