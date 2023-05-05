using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System.Windows;

namespace Library.UI.Commands.SignIn
{
    public class LoginButtonCommand : CommandBase
    {
        private readonly SignInPanelViewModel _signInPanelVM;

        private readonly IUserAuthenticationService _userAuthenticationService;

        public override void Execute(object parameter)
        {
            UserModel databaseUser = UserStoreService.ReturnUser();
            if (databaseUser == null)
            {
                MessageBox.Show("Invalid username or password", "Error");
                return;
            }
            UserViewModel databaseUserVM = MappingService.UserModelToViewModel(databaseUser);
            _userAuthenticationService.Authentication(_signInPanelVM.SignInUsernamePassword.Username, databaseUser.Username, _signInPanelVM.SignInUsernamePassword.Password,
                databaseUser.Password);
            _signInPanelVM.RaisePlaceOfUsageDeletedEvent();
        }

        public LoginButtonCommand(SignInPanelViewModel signInPanelVM, IUserAuthenticationService
            userAuthenticationService)
        {
            _signInPanelVM = signInPanelVM;
            _userAuthenticationService = userAuthenticationService;
        }
    }
}
