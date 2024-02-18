using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WrcaySalesInventorySystem.Models;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem
{
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ApplicationDatabaseContext>(options =>
            {
                options.UseSqlServer(Settings.Default.wrcaydbConenction2);
            });
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(Object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
