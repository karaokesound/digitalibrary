using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class BookDoubleClickCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        public override void Execute(object parameter)
        {
            _libraryViewModel.AreBookDetailsVisible = true;
            _libraryViewModel.ShowBookGrade();
        }

        public BookDoubleClickCommand(LibraryViewModel libraryViewModel)
        {
            _libraryViewModel = libraryViewModel;
        }
    }
}
