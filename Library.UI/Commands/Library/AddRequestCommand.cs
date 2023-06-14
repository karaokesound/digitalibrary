using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System;

namespace Library.UI.Commands.Library
{
    public class AddRequestCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IDataSorting _dataSorting;

        private readonly IMappingService _mappingService;

        public override void Execute(object parameter)
        {
            BookViewModel selectedBookVM = _libraryViewModel.SelectedBook;
            Guid loggedUserId = _libraryViewModel.LoggedAccountId;

            BookModel selectedBook = _mappingService.BookViewModelToModel(selectedBookVM, selectedBookVM.Author);
            var dbSelecteedBook = _bookBaseRepository.GetByID(selectedBook.BookId);
          
            dbSelecteedBook.AnyRequest = true;
            dbSelecteedBook.RequestUserId = loggedUserId;

            _bookBaseRepository.Save();
        }

        public AddRequestCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookModel> bookBaseRepository, IDataSorting dataSorting,
            IMappingService mappingService)
        {
            _libraryViewModel = libraryViewModel;
            _bookBaseRepository = bookBaseRepository;
            _dataSorting = dataSorting;
            _mappingService = mappingService;
        }
    }
}
