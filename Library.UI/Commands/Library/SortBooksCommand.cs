using Library.UI.Command;
using Library.UI.Service.Data;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class SortBooksCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IDataSorting _dataFiltering;

        public override void Execute(object parameter)
        {
            if (_libraryViewModel.SortingMethods == LibraryViewModel.SortingMethod.az)
            {
                _libraryViewModel.DisplayBooks(_dataFiltering.SortBooksAlphabetically());
            }
            else if (_libraryViewModel.SortingMethods == LibraryViewModel.SortingMethod.all)
            {
                _libraryViewModel.DisplayBooks(_dataFiltering.DisplayAllBooks());
            }
        }

        public SortBooksCommand(LibraryViewModel libraryViewModel, IDataSorting dataFiltering)
        {
            _libraryViewModel = libraryViewModel;
            _dataFiltering = dataFiltering;
        }
    }
}
