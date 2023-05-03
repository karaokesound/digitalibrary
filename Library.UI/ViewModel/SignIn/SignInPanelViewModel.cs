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

        public UserViewModel CurrentUser;

        public SignInPanelViewModel()
        {
            SignInUsernamePassword = new UserViewModel();
            CurrentUser = new UserViewModel();
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
            CurrentUser = user;
        }
    }
}
