using Library.Data;
using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System.Linq;
using System.Windows;

namespace Library.UI.Commands.SignIn
{
    public class LoginButtonCommand : CommandBase
    {
        private readonly SignInPanelViewModel _signInPanelVM;

        private readonly IUserAuthenticationService _userAuthenticationService;

        public override void Execute(object parameter)
        {
            UserViewModel user = _signInPanelVM.SignInUsernamePassword;
            using (LibraryDbContext context = new LibraryDbContext())
            {
                UserModel dbUser = context.Users.FirstOrDefault(dbu => dbu.Username == user.Username);
                bool validation = ValidationService.SignInValidation(dbUser, user);
                if (validation == false)
                {
                    return;
                }
                _userAuthenticationService.Authentication(user.Username, dbUser.Username, user.Password,
                    dbUser.Password);
                _signInPanelVM.RaisePlaceOfUsageDeletedEvent();
            }
        }

        public LoginButtonCommand(SignInPanelViewModel signInPanelVM, IUserAuthenticationService
            userAuthenticationService)
        {
            _signInPanelVM = signInPanelVM;
            _userAuthenticationService = userAuthenticationService;
        }
    }
}
