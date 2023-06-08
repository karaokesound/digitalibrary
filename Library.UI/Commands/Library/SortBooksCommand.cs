using Library.UI.Command;
using Library.UI.Service.Data;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;

namespace Library.UI.Commands.Library
{
    public class SortBooksCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IDataSorting _dataSorting;

        private readonly SortingEnums _sortingEnums;

        public override void Execute(object parameter)
        {
            _libraryViewModel.DisplayBooks(_dataSorting.SortBooks
                (_sortingEnums.SortingMethods, _sortingEnums.Quantity, _sortingEnums.Genres));
        }

        public SortBooksCommand(LibraryViewModel libraryViewModel, IDataSorting dataSorting, SortingEnums sortingEnums)
        {
            _libraryViewModel = libraryViewModel;
            _dataSorting = dataSorting;
            _sortingEnums = sortingEnums;
            Execute(libraryViewModel);
        }
    }
}
