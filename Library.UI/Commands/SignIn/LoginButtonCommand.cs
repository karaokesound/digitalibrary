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
            UserModel databaseUserModel = UserStoreService.ReturnUser();
            UserViewModel user = _signInPanelVM.SignInUsernamePassword;
            bool validation = ValidationService.SignInValidation(databaseUserModel, user);
            if (validation == false)
            {
                return;
            }
            _userAuthenticationService.Authentication(user.Username, databaseUserModel.Username, user.Password,
                databaseUserModel.Password);
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
