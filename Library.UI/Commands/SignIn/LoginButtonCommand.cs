using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.SignIn
{
    public class LoginButtonCommand : CommandBase
    {
        private readonly SignInPanelViewModel _signInPanelVM;
        public override void Execute(object parameter)
        {
            _signInPanelVM.GetUsernameAndPassword();
            if ((_signInPanelVM.User.Username == _signInPanelVM.SignInUsernamePassword.Username) &&
                (_signInPanelVM.User.Password == _signInPanelVM.SignInUsernamePassword.Password))
            {
                _signInPanelVM.SelectedViewModel = new AccountPanelViewModel();
            }
            return;
        }

        public LoginButtonCommand(SignInPanelViewModel signInPanelVM)
        {
            _signInPanelVM = signInPanelVM;
        }
    }
}
