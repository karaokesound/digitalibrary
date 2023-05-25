using Library.UI.Command;
using Library.UI.Service.Data;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class SortBooksCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IDataSorting _dataSorting;

        public override void Execute(object parameter)
        {
            _libraryViewModel.DisplayBooks(_dataSorting.SortBooks
                (_libraryViewModel.SortingMethods, _libraryViewModel.Quantity, _libraryViewModel.Genres));
        }

        public SortBooksCommand(LibraryViewModel libraryViewModel, IDataSorting dataSorting)
        {
            _libraryViewModel = libraryViewModel;
            _dataSorting = dataSorting;
            Execute(libraryViewModel);
        }
    }
}
