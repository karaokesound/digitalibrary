using Library.Data;
using Library.Models.Model;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.API;
using Library.UI.Service.Data;
using Library.UI.Services;
using Library.UI.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Library.UI
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        protected async override void OnStartup(StartupEventArgs e)
        {
            using (LibraryDbContext context = new LibraryDbContext())
            {
                context.Database.EnsureCreated();
            }

            MainWindow mainWindow = _serviceProvider.GetService<MainWindow>();
            await mainWindow.MainViewModel.SeedDatabase();
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
            services.AddHttpClient();

            services.AddTransient<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddTransient<AccountPanelViewModel>();
            services.AddTransient<SignUpPanelViewModel>();
            services.AddTransient<SignInPanelViewModel>();
            services.AddTransient<LibraryViewModel>();
            
            // interfaces //
            services.AddSingleton<IUserAuthenticationService, UserAuthenticationService>();
            services.AddSingleton<IValidationService, ValidationService>();
            services.AddSingleton<IBaseRepository<UserModel>, BaseRepository<UserModel>>();
            services.AddSingleton<IBaseRepository<BookModel>, BaseRepository<BookModel>>();
            services.AddSingleton<IBaseRepository<LanguageModel>, BaseRepository<LanguageModel>>();
            services.AddSingleton<IBaseRepository<AuthorModel>, BaseRepository<AuthorModel>>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IMappingService, MappingService>();
            services.AddSingleton<IBookApiService, BookApiService>();
            services.AddTransient<IDataSeeder, DataSeeder>();
            services.AddTransient<IDataSorting, DataSorting>();
        }
    }
}
