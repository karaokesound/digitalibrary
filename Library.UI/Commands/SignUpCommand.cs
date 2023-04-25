using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands
{
    public class SignUpCommand : CommandBase
    {
        private readonly SignUpViewModel _signUpVM;

        public override void Execute(object parameter)
        {
            _signUpVM.SignUpPanelVisibility = true;
        }

        public SignUpCommand(SignUpViewModel signUpVM)
        {
            _signUpVM = signUpVM;
        }
    }
}
