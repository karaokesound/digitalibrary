using Library.UI.Commands;
using Library.UI.Commands.SignIn;
using Library.UI.Model;
using Library.UI.Services;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class SignInPanelViewModel : BaseViewModel
    {
        private bool _signInPanelVisibility;
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

        public UserViewModel User;

        public ICommand SignInButtonCommand { get; }

        public ICommand LoginButtonCommand { get; }

        public SignInPanelViewModel()
        {
            SignInButtonCommand = new SignInButtonCommand(this);
            LoginButtonCommand = new LoginButtonCommand(this);
            SignInUsernamePassword = new UserViewModel();
            User = new UserViewModel();
            GetUsernameAndPassword();
        }

        public void GetUsernameAndPassword()
        {
            UserModel userModel = UserStoreService.ReturnUser();
            if (userModel == null)
            {
                return;
            }
            UserViewModel user = MappingService.UserModelToViewModel(userModel);
            User = user;
        }
    }
}
