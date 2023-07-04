using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service.Library;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System.Collections.Generic;

namespace Library.UI.Commands.Library
{
    public class SortBooksCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IBookOperations _dataSorting;

        private readonly SortingEnums _sortingEnums;

        public List<BookModel> CurrentBookList { get; set; }

        public SortBooksCommand(LibraryViewModel libraryViewModel, IBookOperations dataSorting, SortingEnums sortingEnums)
        {
            _libraryViewModel = libraryViewModel;
            _dataSorting = dataSorting;
            _sortingEnums = sortingEnums;

            // Shows books at the start of an application
            Execute(libraryViewModel);
        }

        public override void Execute(object parameter)
        {
            _libraryViewModel.DisplayBooks(_dataSorting.SortBooks(_sortingEnums.SortingMethods, _sortingEnums.Quantity,
            _sortingEnums.Genres, _sortingEnums.AlphabeticalSortingMethod));

            if (_libraryViewModel.SortingEnums.SortingMethods == SortingEnums.SortingMethod.Az)
            {
                _libraryViewModel.IsAzEnumSelected = true;

                if (_libraryViewModel.SortingEnums.AlphabeticalSortingMethod == SortingEnums.AlphabeticalSorting.NOT_SET) return;
                else
                {
                    _libraryViewModel.DisplayBooks(_dataSorting.SortBooks(_sortingEnums.SortingMethods, _sortingEnums.Quantity,
                        _sortingEnums.Genres, _sortingEnums.AlphabeticalSortingMethod));
                }
            }
            else
            {
                _libraryViewModel.IsAzEnumSelected = false;
                _libraryViewModel.SortingEnums.AlphabeticalSortingMethod = SortingEnums.AlphabeticalSorting.NOT_SET;
            }
        }
    }
}
