using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class LibraryUpdateViewCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryVM;

        public override void Execute(object parameter)
        {
            //if (parameter.ToString() == "Account")
            //{
            //    //_libraryVM.SelectedViewModel = new AccountPanelViewModel();
            //}
        }

        public LibraryUpdateViewCommand(LibraryViewModel libraryVM)
        {
            _libraryVM = libraryVM;
        }
    }
}
