using Library.Models.Model;
using Library.Models.Model.many_to_many;
using Library.UI.Commands.Navigation;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Library;
using Library.UI.Service.Navigation;
using Library.UI.Service.Validation;
using Library.UI.Services;
using Library.UI.Stores;
using System.Windows.Input;

namespace Library.UI.ViewModel.Navigation
{
    public class NavigationPanelViewModel : BaseViewModel
    {
        public delegate void UserLoggedOutEvent(bool isLoggedOut);

        public event UserLoggedOutEvent UserLoggedOut = null;

        public ICommand NavigateProfileCommand { get; }

        public ICommand NavigateLibraryCommand { get; }

        public ICommand LogoutCommand { get; }

        public LibraryViewModel LibraryVM { get; }

        public ProfilePanelViewModel ProfilePanelVM { get; }

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IBookOperations _dataSorting;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        private readonly IElementVisibilityService _elementVisibilityService;

        private readonly IBaseRepository<BookGradeModel> _bookgradeBaseRepository;

        private readonly IBaseRepository<GradeModel> _gradeBaseRepository;

        private readonly NavigationStore _navigationStore;

        private readonly BookStore _booksStore;

        public NavigationPanelViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService, IBookOperations dataSorting,
            IUserAuthenticationService userAuthenticationService, IValidationService validationService, IUserRepository userRepository,
            IBaseRepository<AccountModel> accountBaseRepository, IAccountBookRepository accountBookRepository, IElementVisibilityService elementVisibilityService,
            IBaseRepository<BookGradeModel> bookgradeBaseRepository, IBaseRepository<GradeModel> gradeBaseRepository, NavigationStore navigationStore,
            LibraryViewModel libraryVM, ProfilePanelViewModel profilePanelVM, BookStore booksStore)
        {
            LibraryVM = libraryVM;
            ProfilePanelVM = profilePanelVM;
            _booksStore = booksStore;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataSorting = dataSorting;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            _elementVisibilityService = elementVisibilityService;
            _bookgradeBaseRepository = bookgradeBaseRepository;
            _gradeBaseRepository = gradeBaseRepository;
            _navigationStore = navigationStore;

            NavigateLibraryCommand = new NavigateCommand<LibraryViewModel>(new NavigationService<LibraryViewModel>
                (navigationStore, () => new LibraryViewModel(_bookBaseRepository, _mappingService, _dataSorting,
                    _userAuthenticationService, _validationService, _userRepository, _accountBaseRepository, _accountBookRepository, _elementVisibilityService,
                    _bookgradeBaseRepository, _gradeBaseRepository, _booksStore)));

            NavigateProfileCommand = new NavigateCommand<ProfilePanelViewModel>(new NavigationService<ProfilePanelViewModel>(navigationStore,
               () => new ProfilePanelViewModel(_bookBaseRepository, _mappingService, _dataSorting, _userAuthenticationService,
                       _validationService, _userRepository, _accountBaseRepository, _accountBookRepository, _elementVisibilityService,
                       _bookgradeBaseRepository, _gradeBaseRepository, _navigationStore)));

            LogoutCommand = new LogoutCommand(this, _userAuthenticationService);
        }

        public void RaiseUserLoggedOutEvent()
        {
            UserLoggedOut?.Invoke(_userAuthenticationService.IsUserAuthenticated);
        }
    }
}
