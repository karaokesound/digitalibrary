using Library.UI.Command;
using Library.UI.Service.Data;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Controls;
using System.Windows.Documents;

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
                (_sortingEnums.SortingMethods, _sortingEnums.Quantity, _sortingEnums.Genres, _sortingEnums.AlphabeticalSortingMethod));

            if (_libraryViewModel.SortingEnums.SortingMethods == SortingEnums.SortingMethod.Az)
            {
                _libraryViewModel.IsAzEnumSelected = true;

                if (_libraryViewModel.SortingEnums.AlphabeticalSortingMethod == SortingEnums.AlphabeticalSorting.NOT_SET)
                {
                    return;
                }
                else
                {
                    _libraryViewModel.DisplayBooks(_dataSorting.SortBooks
                        (_sortingEnums.SortingMethods, _sortingEnums.Quantity, _sortingEnums.Genres, _sortingEnums.AlphabeticalSortingMethod));
                }
            }
            else
            {
                _libraryViewModel.IsAzEnumSelected = false;
                _libraryViewModel.SortingEnums.AlphabeticalSortingMethod = SortingEnums.AlphabeticalSorting.NOT_SET;
            }
        }

        public SortBooksCommand(LibraryViewModel libraryViewModel, IDataSorting dataSorting, SortingEnums sortingEnums)
        {
            _libraryViewModel = libraryViewModel;
            _dataSorting = dataSorting;
            _sortingEnums = sortingEnums;

            // shows books at the start of an application
            Execute(libraryViewModel);
        }
    }
}
