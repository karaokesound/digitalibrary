using Library.UI.Command;
using Library.UI.Services;
using Library.UI.ViewModel.Navigation;

namespace Library.UI.Commands.Navigation
{
    public class LogoutCommand : CommandBase
    {
        private readonly NavigationPanelViewModel _navigationPanelVM;

        private readonly IUserAuthenticationService _userAuthService;

        public LogoutCommand(NavigationPanelViewModel navigationPanelVM, IUserAuthenticationService userAuthService)
        {
            _navigationPanelVM = navigationPanelVM;
            _userAuthService = userAuthService;
        }

        public override void Execute(object parameter)
        {
            bool isLoggedOut = true;
            _userAuthService.UserLogout(isLoggedOut);
            _navigationPanelVM.RaiseUserLoggedOutEvent();
        }
    }
}
