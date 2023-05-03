using Library.UI.Command;
using Library.UI.Services;
using Library.UI.ViewModel;

namespace Library.UI.Commands.SignIn
{
    public class LoginButtonCommand : CommandBase
    {
        private readonly SignInPanelViewModel _signInPanelVM;

        private readonly MainViewModel _mainVM;

        private readonly IUserAuthenticationService _userAuthenticationService;

        public override void Execute(object parameter)
        {
            bool authenticationResult = _userAuthenticationService.Authentication(
                _signInPanelVM.SignInUsernamePassword.Username, _signInPanelVM.SignInUsernamePassword.Password);
            _mainVM.IsUserAuthenticated = authenticationResult;
        }

        public LoginButtonCommand(SignInPanelViewModel signInPanelVM, MainViewModel mainVM, IUserAuthenticationService
            userAuthenticationService)
        {
            _signInPanelVM = signInPanelVM;
            _mainVM = mainVM;
            _userAuthenticationService = userAuthenticationService;
        }
    }
}
