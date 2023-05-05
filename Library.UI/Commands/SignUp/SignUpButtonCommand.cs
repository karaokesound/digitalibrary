using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands
{
    public class SignUpButtonCommand : CommandBase
    {
        private readonly SignUpPanelViewModel _signUpPanelVM;

        public override void Execute(object parameter)
        {
            
            _signUpPanelVM.MainWindowButtonVisibility = false;
            _signUpPanelVM.SignUpPanelVisibility = true;
            _signUpPanelVM.SignInPanelViewModel.SignInPanelVisibility = false;
        }

        public SignUpButtonCommand(SignUpPanelViewModel signUpPanelVM)
        {
            _signUpPanelVM = signUpPanelVM;
        }
    }
}
