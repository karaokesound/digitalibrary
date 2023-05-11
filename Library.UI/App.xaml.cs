using Library.Data;
using Library.UI.Data;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Windows;

namespace Library.UI
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            //using (LibraryDbContext context = new LibraryDbContext())
            //{
            //    context.Database.EnsureCreated();
            //}

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
            services.AddDbContext<LibraryDbContext>();
            services.AddTransient<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddTransient<BookCollectionViewModel>();
            services.AddTransient<AccountPanelViewModel>();
            services.AddTransient<SignUpPanelViewModel>();
            services.AddTransient<SignInPanelViewModel>();

            // interfaces //
            services.AddSingleton<IBookDataProvider, BookDataProvider>();
            services.AddSingleton<IUserAuthenticationService, UserAuthenticationService>();
            services.AddSingleton<IBaseRepository<UserModel>, BaseRepository<UserModel>>();
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
