using Library.Data;
using Library.Models.Model;
using Library.Models.Model.many_to_many;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.API;
using Library.UI.Service.Data;
using Library.UI.Service.Library;
using Library.UI.Service.Validation;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using Library.UI.ViewModel.Navigation;
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

            base.OnStartup(e);

            MainWindow mainWindow = _serviceProvider.GetService<MainWindow>();

            if (mainWindow?.MainViewModel != null)
            {
                await mainWindow.MainViewModel.SeedDatabase();
            }

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
            services.AddTransient<ProfilePanelViewModel>();
            services.AddTransient<SignUpPanelViewModel>();
            services.AddTransient<SignInPanelViewModel>();
            services.AddTransient<LibraryViewModel>();
            services.AddTransient<SortingEnums>();
            services.AddTransient<NavigationPanelViewModel>();

            // interfaces //
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<IUserAuthenticationService, UserAuthenticationService>();
            services.AddSingleton<IValidationService, ValidationService>();
            services.AddSingleton<IBaseRepository<AccountModel>, BaseRepository<AccountModel>>();
            services.AddSingleton<IBaseRepository<BookModel>, BaseRepository<BookModel>>();
            services.AddSingleton<IBaseRepository<LanguageModel>, BaseRepository<LanguageModel>>();
            services.AddSingleton<IBaseRepository<AuthorModel>, BaseRepository<AuthorModel>>();
            services.AddSingleton<IBaseRepository<BookLanguageModel>, BaseRepository<BookLanguageModel>>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IMappingService, MappingService>();
            services.AddSingleton<IBookApiService, BookApiService>();
            services.AddTransient<IDataSeeder, DataSeeder>();
            services.AddTransient<IDataSorting, DataSorting>();
            services.AddTransient<IElementVisibilityService, ElementVisibilityService>();
            services.AddTransient<IBaseRepository<AccountModel>, BaseRepository<AccountModel>>();
            services.AddTransient<IAccountBookRepository, AccountBookRepository>();
            services.AddSingleton<IBaseRepository<BookGradeModel>, BaseRepository<BookGradeModel>>();
            services.AddSingleton<IBaseRepository<GradeModel>, BaseRepository<GradeModel>>();
        }
    }
}
