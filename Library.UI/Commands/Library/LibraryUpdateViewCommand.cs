using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;

namespace Library.UI.Commands.Library
{
    public class LibraryUpdateViewCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryVM;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataSorting;

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Account")
            {
                _libraryVM.SelectedViewModel = new AccountPanelViewModel(_bookBaseRepository, _mappingService, _dataSorting);
            }
        }

        public LibraryUpdateViewCommand(LibraryViewModel libraryVM, IBaseRepository<BookModel> bookBaseRepository, 
            IMappingService mappingService, IDataSorting dataSorting)
        {
            _libraryVM = libraryVM;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataSorting = dataSorting;
        }
    }
}
