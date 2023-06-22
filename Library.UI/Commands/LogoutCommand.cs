using Library.UI.Command;
using Library.UI.Services;
using Library.UI.ViewModel;
using System;

namespace Library.UI.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly IUserAuthenticationService _userAuthService;

        private readonly ProfilePanelViewModel _profilePanelVM;

        public LogoutCommand(IUserAuthenticationService userAuthService, ProfilePanelViewModel profilePanelVM)
        {
            _userAuthService = userAuthService;
            _profilePanelVM = profilePanelVM;
        }

        public override void Execute(object parameter)
        {
            bool isLoggedOut = true;

            _userAuthService.UserLogout(isLoggedOut);
            _profilePanelVM.LogoutValidation();
        }
    }
}
