using Library.UI.Command;
using Library.UI.Data;
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
            else if (parameter.ToString() == "BookCollection")
            {
                _mainVM.SelectedViewModel = new BookCollectionViewModel(new BookDataProvider());
            }
        }

        public UpdateViewCommand(MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
