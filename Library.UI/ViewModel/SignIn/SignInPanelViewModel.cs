using Library.UI.Commands.SignIn;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.SignUp;
using Library.UI.Services;
using Library.UI.Stores;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class SignInPanelViewModel : BaseViewModel
    {
        public delegate void UserAuthenticationChangedEvent(bool userAuthentication);

        public event UserAuthenticationChangedEvent UserAuthenticationChanged = null!;

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

        private bool _signInPanelVisibility = true;
        public bool SignInPanelVisibility
        {
            get => _signInPanelVisibility;
            set
            {
                _signInPanelVisibility = value;
                OnPropertyChanged();
            }
        }

        private AccountViewModel _loggingUsernamePassword;
        public AccountViewModel LoggingUsernamePassword
        {
            get => _loggingUsernamePassword;
            set 
            { 
                _loggingUsernamePassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public BookStore BookStore { get; set; }

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IMappingService _mappingService;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly INotificationService _notificationService;

        private readonly AccountViewModel _accountVM;

        public SignInPanelViewModel(IUserAuthenticationService userAuthenticationService, IValidationService validationService, 
            IUserRepository userRepository, IMappingService mappingService, IBaseRepository<BookModel> bookBaseRepository,
            INotificationService notificationService, AccountViewModel accountVM)
        {
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _mappingService = mappingService;
            _bookBaseRepository = bookBaseRepository;
            _notificationService = notificationService;
            _accountVM = accountVM;
            BookStore = new BookStore(this);
            LoggingUsernamePassword = new AccountViewModel(_notificationService);
            LoginCommand = new LoginCommand(this, _userAuthenticationService, _validationService, _userRepository, _mappingService,
                _bookBaseRepository, _accountVM);
        }

        public void RaiseUserAuthEvent() => UserAuthenticationChanged?.Invoke(_userAuthenticationService.IsUserAuthenticated);

        public void ErasePasswordBox()
        {
            LoggingUsernamePassword.Password = string.Empty;
            LoggingUsernamePassword.Username = string.Empty;
            OnPropertyChanged(nameof(LoggingUsernamePassword));
        }
    }
}
