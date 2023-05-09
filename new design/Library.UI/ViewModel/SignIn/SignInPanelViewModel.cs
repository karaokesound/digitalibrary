using Library.UI.Commands.SignIn;
using Library.UI.Model;
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

        private UserViewModel _signInUsernamePassword;
        public UserViewModel SignInUsernamePassword
        {
            get => _signInUsernamePassword;
            set 
            { 
                _signInUsernamePassword = value;
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

        public UserViewModel CurrentUser;
        
        public ICommand LoginButtonCommand { get; }

        private readonly IUserAuthenticationService _userAuthenticationService;

        public SignInPanelViewModel(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
            SignInUsernamePassword = new UserViewModel();
            CurrentUser = new UserViewModel();
            LoginButtonCommand = new LoginButtonCommand(this, _userAuthenticationService);
            GetUsernameAndPassword();
        }

        public void RaisePlaceOfUsageDeletedEvent() => UserAuthenticationChanged?.Invoke(_userAuthenticationService.IsUserAuthenticated);

        public void GetUsernameAndPassword()
        {
            UserModel userModel = UserStoreService.ReturnUser();
            if (userModel == null)
            {
                return;
            }
            UserViewModel user = MappingService.UserModelToViewModel(userModel);
            CurrentUser = user;
        }
    }
}
