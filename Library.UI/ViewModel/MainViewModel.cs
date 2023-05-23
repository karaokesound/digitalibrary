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

        private readonly IDataFiltering _dataFiltering;

        public MainViewModel(AccountPanelViewModel accountPanelVM, SignUpPanelViewModel signUpPanelVM, SignInPanelViewModel signInPanelVM,
			LibraryViewModel libraryVM, IDataSeeder dataSeeder, IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService,
			IDataFiltering dataFiltering)
        {
			AccountPanelVM = accountPanelVM;
			SignUpPanelVM = signUpPanelVM;
			SignInPanelVM = signInPanelVM;
			LibraryVM = libraryVM;
            _dataSeeder = dataSeeder;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataFiltering = dataFiltering;
			UpdateView();

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

		public async Task SeedDatabase()
		{
			await _dataSeeder.SeedDataBase(); 
		}

		public void UpdateView()
		{
			SelectedViewModel = new LibraryViewModel(_bookBaseRepository, _mappingService, _dataFiltering);
		}
		
	
    }
}
