using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class FilterBooksCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        public override void Execute(object parameter)
        {
            string letter = _libraryViewModel.SearchBoxString;
        }

        public FilterBooksCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookModel> bookBaseRepository)
        {
            _libraryViewModel = libraryViewModel;
            _bookBaseRepository = bookBaseRepository;
        }
    }
}
