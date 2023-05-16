using Library.UI.Commands.SignIn;
using Library.UI.Service;
using Library.UI.Services;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class SignInPanelViewModel : BaseViewModel
    {
        public delegate void UserAuthenticationChangedEvent(bool userAuthentication);

        public event UserAuthenticationChangedEvent UserAuthenticationChanged = null!;

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

        private UserViewModel _loggingUsernamePassword;
        public UserViewModel LoggingUsernamePassword
        {
            get => _loggingUsernamePassword;
            set 
            { 
                _loggingUsernamePassword = value;
                OnPropertyChanged();
            }
        }

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

        public ICommand LoginCommand { get; }

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IMappingService _mappingService;

        public SignInPanelViewModel(IUserAuthenticationService userAuthenticationService, IValidationService validationService, 
            IUserRepository userRepository, IMappingService mappingService)
        {
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _mappingService = mappingService;
            LoggingUsernamePassword = new UserViewModel(_validationService);
            LoginCommand = new LoginCommand(this, _userAuthenticationService, _validationService, _userRepository, _mappingService);
        }

        public void RaiseUserAuthEvent() => UserAuthenticationChanged?.Invoke(_userAuthenticationService.IsUserAuthenticated);
    }
}
