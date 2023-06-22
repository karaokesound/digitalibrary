using Library.Models.Model;
using Library.Models.Model.many_to_many;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Service.Validation;
using Library.UI.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        public BaseViewModel SelectedViewModel => _navigationStore.CurrentViewModel;

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

        private bool _isButtonClicked;
        public bool IsButtonClicked
        {
            get => _isButtonClicked;
            set
            {
                _isButtonClicked = value;
                OnPropertyChanged();
            }
        }

        private bool _isElementVisible = true;
        public bool IsElementVisible
        {
            get => _isElementVisible;
            set
            {
                _isElementVisible = value;
                OnPropertyChanged();
            }
        }

        public ProfilePanelViewModel ProfilePanelVM { get; }

        public SignUpPanelViewModel SignUpPanelVM { get; }

        public SignInPanelViewModel SignInPanelVM { get; }

        public LibraryViewModel LibraryVM { get; }

        public ICommand NavigateLoginCommand { get; }

        private readonly IDataSeeder _dataSeeder;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataSorting;

        private readonly IElementVisibilityService _elementVisibilityService;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        private readonly IBaseRepository<BookGradeModel> _bookgradeBaseRepository;

        private readonly IBaseRepository<GradeModel> _gradeBaseRepository;

        public MainViewModel(ProfilePanelViewModel profilePanelVM, SignUpPanelViewModel signUpPanelVM, SignInPanelViewModel signInPanelVM,
            LibraryViewModel libraryVM, IDataSeeder dataSeeder, IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService,
            IDataSorting dataSorting, IElementVisibilityService elementVisibilityService, IUserAuthenticationService userAuthenticationService,
            IValidationService validationService, IUserRepository userRepository, IBaseRepository<AccountModel> accountBaseRepository,
            IAccountBookRepository accountBookRepository, IBaseRepository<BookGradeModel> bookgradeBaseRepository, IBaseRepository<GradeModel> gradeBaseRepository,
            NavigationStore navigationStore)
        {
            ProfilePanelVM = profilePanelVM;
            SignUpPanelVM = signUpPanelVM;
            SignInPanelVM = signInPanelVM;
            LibraryVM = libraryVM;
            _dataSeeder = dataSeeder;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataSorting = dataSorting;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            _bookgradeBaseRepository = bookgradeBaseRepository;
            _gradeBaseRepository = gradeBaseRepository;
            _navigationStore = navigationStore;
            _elementVisibilityService = elementVisibilityService;
            ElementsVisibility();
            LoggingValidation();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        // This methood is initialized in App.xaml.cs. There is no need to initialize it in MainViewModel constructor.
        public async Task SeedDatabase()
        {
            await _dataSeeder.SeedDataBase();
        }

        public void ElementsVisibility()
        {
            SignUpPanelVM.SignUpButtonClicked += (isButtonClicked) =>
            {
                IsButtonClicked = isButtonClicked;
                if (IsButtonClicked == true)
                {
                    IsElementVisible = false;
                }
                else
                {
                    IsElementVisible = true;
                }
            };
        }

        public void LoggingValidation()
        {
            SignInPanelVM.UserAuthenticationChanged += (isUserAuthenticated) =>
            {
                IsUserAuthenticated = isUserAuthenticated;
                if (IsUserAuthenticated == true)
                {
                    _navigationStore.CurrentViewModel = new ProfilePanelViewModel(_bookBaseRepository, _mappingService, _dataSorting, _userAuthenticationService,
                        _validationService, _userRepository, _accountBaseRepository, _accountBookRepository, _elementVisibilityService, _bookgradeBaseRepository,
                        _gradeBaseRepository, _navigationStore);
                }
                else return;
            };
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
