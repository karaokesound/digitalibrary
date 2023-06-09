﻿using Library.Models.Model;
using Library.Models.Model.many_to_many;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Service.Library;
using Library.UI.Service.Validation;
using Library.UI.Services;
using Library.UI.Store;
using Library.UI.Stores;
using Library.UI.ViewModel.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel SelectedViewModel => _navigationStore.CurrentViewModel;

        private bool _isUserAuthenticated;
        public bool IsUserAuthenticated
        {
            get => _isUserAuthenticated;
            set
            {
                _isUserAuthenticated = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsUserAuthenticatedNegation));
            }
        }

        public bool IsUserAuthenticatedNegation
        {
            get => !IsUserAuthenticated;
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
        public NavigationPanelViewModel NavigationPanelVM { get; }
        public ICommand NavigateLoginCommand { get; }

        private readonly IDataSeeder _dataSeeder;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IBookOperations _bookOperations;

        private readonly IElementVisibilityService _elementVisibilityService;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        private readonly IBaseRepository<BookGradeModel> _bookgradeBaseRepository;

        private readonly IBaseRepository<GradeModel> _gradeBaseRepository;

        private readonly NavigationStore _navigationStore;

        private readonly BookStore _bookStore;

        public MainViewModel(ProfilePanelViewModel profilePanelVM, SignUpPanelViewModel signUpPanelVM, SignInPanelViewModel signInPanelVM,
            LibraryViewModel libraryVM, IDataSeeder dataSeeder, IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService,
            IBookOperations bookOperations, IElementVisibilityService elementVisibilityService, IUserAuthenticationService userAuthenticationService,
            IValidationService validationService, IUserRepository userRepository, IBaseRepository<AccountModel> accountBaseRepository,
            IAccountBookRepository accountBookRepository, IBaseRepository<BookGradeModel> bookgradeBaseRepository, IBaseRepository<GradeModel> gradeBaseRepository,
            NavigationStore navigationStore, NavigationPanelViewModel navigationPanelVM, BookStore bookStore)
        {
            ProfilePanelVM = profilePanelVM;
            SignUpPanelVM = signUpPanelVM;
            SignInPanelVM = signInPanelVM;
            LibraryVM = libraryVM;
            NavigationPanelVM = navigationPanelVM;
            _bookStore = bookStore;
            _dataSeeder = dataSeeder;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _bookOperations = bookOperations;
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
            LogoutUser();

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
                    _navigationStore.CurrentViewModel = new LibraryViewModel(_bookBaseRepository, _mappingService, _bookOperations,
                            _userAuthenticationService, _validationService, _userRepository, _accountBaseRepository, _accountBookRepository, _elementVisibilityService,
                            _bookgradeBaseRepository, _gradeBaseRepository, _bookStore);
                    _navigationStore.CurrentViewModel = new ProfilePanelViewModel(_bookBaseRepository, _mappingService, _userAuthenticationService,
                        _accountBaseRepository, _accountBookRepository, _elementVisibilityService);
                }
                else return;
            };
        }

        public void LogoutUser()
        {
            NavigationPanelVM.UserLoggedOut += (isUserLoggedOut) =>
            {
                IsUserAuthenticated = isUserLoggedOut;
            };
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
