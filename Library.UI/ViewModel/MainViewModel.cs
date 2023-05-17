using Library.Data;
using Library.UI.Model;
using Library.UI.Service.API;
using Library.UI.Service.Data;
using Library.UI.Services;
using System.Linq;

namespace Library.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
		private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
		{
			get => _selectedViewModel;
			set 
			{ 
				_selectedViewModel = value;
				OnPropertyChanged();
			}
		}
		public AccountPanelViewModel AccountPanelVM { get; }

        public SignUpPanelViewModel SignUpPanelVM { get; }

        public SignInPanelViewModel SignInPanelVM { get; }

		public LibraryViewModel LibraryVM { get; }

        private readonly DataSeeder _dataSeeder;

        private readonly LibraryDbContext _libraryDbContext;

		private bool _isUserAuthenticated;

        public bool IsUserAuthenticated
		{
			get => _isUserAuthenticated;
			set 
			{ 
				_isUserAuthenticated = value;
				OnPropertyChanged();
			}
		}

        public MainViewModel(AccountPanelViewModel accountPanelVM, SignUpPanelViewModel signUpPanelVM, SignInPanelViewModel signInPanelVM,
			LibraryViewModel libraryVM, DataSeeder dataSeeder, LibraryDbContext libraryDbContext)
        {
			AccountPanelVM = accountPanelVM;
			SignUpPanelVM = signUpPanelVM;
			SignInPanelVM = signInPanelVM;
			LibraryVM = libraryVM;
            _dataSeeder = dataSeeder;
            _libraryDbContext = libraryDbContext;
            CheckDatabase();

            // login button //
            SelectedViewModel = new LibraryViewModel(new BaseRepository<BookModel>(), new MappingService(new ValidationService()));
			SignInPanelVM.UserAuthenticationChanged += (isUserAuthenticated) =>
			{
				IsUserAuthenticated = isUserAuthenticated;
				if (IsUserAuthenticated == true)
				{
					SelectedViewModel = new AccountPanelViewModel();
				}
				else return;
			};
		}
		
		public async void CheckDatabase()
		{
			if (_libraryDbContext.Books.Any())
			{
				return;
			}
			ApiBookBase apiBookBase = new ApiBookBase(new DataSeeder(new BaseRepository<BookModel>()));
		}
    }
}
