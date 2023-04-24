using Library.UI.Data;
using Library.UI.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Library.UI
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<BookCollectionViewModel>();
            services.AddTransient<AccountPanelViewModel>();
            services.AddTransient<LofiCollectionViewModel>();

            // interfaces //
            services.AddTransient<IBookDataProvider, BookDataProvider>();
            services.AddTransient<ILofiDataProvider, LofiDataProvider>();
        }
    }
}
