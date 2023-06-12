using Library.Models.Model;
using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System;
using System.Windows;

namespace Library.UI.Commands.Library
{
    public class ReturnBookCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        private readonly IMappingService _mappingService;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IDataSorting _dataSorting;

        public override void Execute(object parameter)
        {
            BookViewModel selectedBookVM = _libraryViewModel.SelectedBook;
            BookModel selectedBook = _mappingService.BookViewModelToModel(selectedBookVM, selectedBookVM.Author);

            AccountModel dbLoggedUser = _accountBaseRepository.GetByID(_libraryViewModel.LoggedAccountId);
            BookModel dbSelecteedBook = _bookBaseRepository.GetByID(selectedBook.BookId);

            dbLoggedUser.MaxBookQntToRent += 1;

            AccountBookModel rentedBook = _accountBookRepository.GetUserBooks(dbLoggedUser.AccountId, selectedBook.BookId);

            if (rentedBook == null)
            {
                MessageBox.Show("You didn't rent this book.");
                return;
            }

            rentedBook.Quantity -= 1;

            if (rentedBook.Quantity == 0)
            {
                _accountBookRepository.DeleteUserBook(dbLoggedUser.AccountId, rentedBook.BookId);

                dbSelecteedBook.IsRented = false;
                dbSelecteedBook.Quantity += 1;
            }

            _accountBaseRepository.Save();
            _accountBookRepository.Save();
            _bookBaseRepository.Save();

            var sortedBooks = _dataSorting.SortBooks(SortingEnums.SortingMethod.NOT_SET, SortingEnums.BookQuantity.NOT_SET, SortingEnums.Genre.NOT_SET);
            _libraryViewModel.DisplayBooks(sortedBooks);
        }

        public ReturnBookCommand(LibraryViewModel libraryViewModel, IBaseRepository<AccountModel> accountBaseRepository,
            IAccountBookRepository accountBookRepository, IMappingService mappingService, IBaseRepository<BookModel> bookBaseRepository,
            IDataSorting dataSorting)
        {
            _libraryViewModel = libraryViewModel;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            _mappingService = mappingService;
            _bookBaseRepository = bookBaseRepository;
            _dataSorting = dataSorting;
        }
    }
}
