using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using System.Threading.Tasks;

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

        public AccountPanelViewModel AccountPanelVM { get; }

        public SignUpPanelViewModel SignUpPanelVM { get; }

        public SignInPanelViewModel SignInPanelVM { get; }

		public LibraryViewModel LibraryVM { get; }

        private readonly IDataSeeder _dataSeeder;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataFiltering;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        public MainViewModel(AccountPanelViewModel accountPanelVM, SignUpPanelViewModel signUpPanelVM, SignInPanelViewModel signInPanelVM,
			LibraryViewModel libraryVM, IDataSeeder dataSeeder, IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService,
			IDataSorting dataFiltering)
        {
			AccountPanelVM = accountPanelVM;
			SignUpPanelVM = signUpPanelVM;
			SignInPanelVM = signInPanelVM;
			LibraryVM = libraryVM;
            _dataSeeder = dataSeeder;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataFiltering = dataFiltering;
            //_userAuthenticationService = userAuthenticationService;
            //_validationService = validationService;
            //_userRepository = userRepository;

            // login button //
            //SignInPanelVM.UserAuthenticationChanged += (isUserAuthenticated) =>
            //{
            //	IsUserAuthenticated = isUserAuthenticated;
            //	if (IsUserAuthenticated == true)
            //	{
            //		SelectedViewModel = new AccountPanelViewModel();
            //	}
            //	else return;
            //};
        }

        // This methood is initialized in App.xaml.cs. There is no need to initialize it in MainViewModel constructor.
		public async Task SeedDatabase()
		{
			await _dataSeeder.SeedDataBase();
            //UpdateView();
		}

        //public void UpdateView()
        //{
        //    SelectedViewModel = new MainViewModel(AccountPanelVM, SignInPanelVM, SignUpPanelVM, LibraryVM, _dataSeeder, _bookBaseRepository, _mappingService, _dataFiltering)
        //}
    }
}
