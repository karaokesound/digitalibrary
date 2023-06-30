using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class LibraryReturnButtonCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        public override void Execute(object parameter)
        {
            _libraryViewModel.AreBookDetailsVisible = false;
            _libraryViewModel.SelectedBook = null;
        }

        public LibraryReturnButtonCommand(LibraryViewModel libraryViewModel)
        {
            _libraryViewModel = libraryViewModel;
        }
    }
}
