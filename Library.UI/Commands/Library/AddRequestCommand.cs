using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System;
using System.Windows;

namespace Library.UI.Commands.Library
{
    public class AddRequestCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        public override void Execute(object parameter)
        {
            if (_libraryViewModel.SelectedBook.Quantity > 1)
            {
                string wMessage = "This book is available. You don't have to make a reservation.";
                string wCaption = "Library";
                MessageBox.Show(wMessage, wCaption);
                return;
            }

            BookViewModel selectedBookVM = _libraryViewModel.SelectedBook;
            Guid loggedUserId = _libraryViewModel.LoggedAccountId;

            BookModel selectedBook = _mappingService.BookViewModelToModel(selectedBookVM, selectedBookVM.Author);
            var dbSelecteedBook = _bookBaseRepository.GetByID(selectedBook.BookId);
          
            dbSelecteedBook.AnyRequest = true;
            dbSelecteedBook.RequestUserId = loggedUserId;

            string sMessage = $"You have made a reservation for {selectedBook.Title}. We'll get you know when it's available";
            string sCaption = "Reservation";
            MessageBox.Show(sMessage, sCaption);

            _bookBaseRepository.Save();
        }

        public AddRequestCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService)
        {
            _libraryViewModel = libraryViewModel;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
        }
    }
}
