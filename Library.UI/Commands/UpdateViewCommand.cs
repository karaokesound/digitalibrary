using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands
{
    public class UpdateViewCommand : CommandBase
    {
        private readonly MainViewModel _mainVM;

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Account")
            {
                _mainVM.SelectedViewModel = new AccountPanelViewModel();
            }
        }

        public UpdateViewCommand(MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
