using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.SignIn
{
    class SignInButtonCommand : CommandBase
    {
        private readonly SignInPanelViewModel _signInPanelVM;

        public override void Execute(object parameter)
        {
            if (_signInPanelVM.SignInPanelVisibility == false)
            {
                _signInPanelVM.SignInPanelVisibility = true;
                return;
            }
            _signInPanelVM.SignInPanelVisibility = false;

        }

        public SignInButtonCommand(SignInPanelViewModel signInPanelVM)
        {
            _signInPanelVM = signInPanelVM;
        }
    }
}
