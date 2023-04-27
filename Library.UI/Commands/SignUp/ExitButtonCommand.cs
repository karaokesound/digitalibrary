using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands
{
    public class ExitButtonCommand : CommandBase
    {
        private readonly SignUpPanelViewModel _signUpPanelVM;

        public override void Execute(object parameter)
        {
            _signUpPanelVM.SignUpPanelVisibility = false;
            _signUpPanelVM.MainWindowButtonVisibility = true;
        }

        public ExitButtonCommand(SignUpPanelViewModel signUpPanelVM)
        {
            _signUpPanelVM = signUpPanelVM;
        }
    }
}
