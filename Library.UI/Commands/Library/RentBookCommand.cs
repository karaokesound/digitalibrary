using Library.Models.Model;
using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Service.Validation;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System.Linq;
using System.Windows;

namespace Library.UI.Commands.Library
{
    public class RentBookCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IDataSorting _dataSorting;

        private readonly IMappingService _mappingService;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;
        private readonly IAccountBookRepository _accountBookRepository;
        private readonly IElementVisibilityService _elementVisibilityService;

        public override void Execute(object parameter)
        {
            AccountModel loggedUser = _accountBaseRepository.GetByID(_libraryViewModel.LoggedAccountId);

            BookViewModel selectedBookVM = _libraryViewModel.BookList.FirstOrDefault(b => b.BookId == _libraryViewModel.SelectedBook.BookId);
            BookModel selectedBook = _mappingService.BookViewModelToModel(selectedBookVM, selectedBookVM.Author);
            BookModel dbBook = _bookBaseRepository.GetByID(selectedBook.BookId);

            // Database operations
            if (selectedBook.Quantity == 0)
            {
                MessageBox.Show("You can't rent this book. We don't have any copies in the library. Send a request to rent this book if available.");
                return;
            }

            if (loggedUser.MaxBookQntToRent == 0)
            {
                MessageBox.Show("Error. Too many books rented.");
                return;
            }

            // Checking if logged user has rent any copy of this book before
            if (dbBook.AnyRequest == true && loggedUser.AccountId == dbBook.RequestUserId)
            {
                int selBookQuantityOnUserAccount = _accountBookRepository.ReturnAccountBookQuantity(loggedUser.AccountId, selectedBook.BookId);

                if (selBookQuantityOnUserAccount == 0)
                {
                    var newRentedBook = new AccountBookModel()
                    {
                        AccountId = loggedUser.AccountId,
                        BookId = selectedBook.BookId,
                        Quantity = 1
                    };

                    _accountBookRepository.Insert(newRentedBook);

                    loggedUser.MaxBookQntToRent -= 1;

                    dbBook.IsRented = true;
                    dbBook.Quantity -= 1;
                    dbBook.AnyRequest = false;
                }
                else
                {
                    var existingRentedBook = _accountBookRepository.GetUserBookByID(loggedUser.AccountId, selectedBook.BookId);
                    if (existingRentedBook != null)
                    {
                        existingRentedBook.Quantity += 1;
                    }

                    loggedUser.MaxBookQntToRent -= 1;
                    dbBook.Quantity -= 1;
                    dbBook.AnyRequest = false;
                }
            }
            else if (dbBook.AnyRequest == true && loggedUser.AccountId != dbBook.RequestUserId)
            {
                MessageBox.Show("You can't rent this book. This book has reservation by another user"); return;
            }
            else
            {
                int selectedBookQuantity = _accountBookRepository.ReturnAccountBookQuantity(loggedUser.AccountId, selectedBook.BookId);

                if (selectedBookQuantity == 0)
                {
                    var newRentedBook = new AccountBookModel()
                    {
                        AccountId = loggedUser.AccountId,
                        BookId = selectedBook.BookId,
                        Quantity = 1
                    };

                    _accountBookRepository.Insert(newRentedBook);

                    loggedUser.MaxBookQntToRent -= 1;

                    dbBook.IsRented = true;
                    dbBook.Quantity -= 1;
                }
                else
                {
                    var existingRentedBook = _accountBookRepository.GetUserBookByID(loggedUser.AccountId, selectedBook.BookId);
                    if (existingRentedBook != null)
                    {
                        existingRentedBook.Quantity += 1;
                    }

                    loggedUser.MaxBookQntToRent -= 1;
                    dbBook.Quantity -= 1;
                }
            }

            bool isProfileListViewVisible = false;
            _elementVisibilityService.AdjustListViewVisibility(isProfileListViewVisible);

            _bookBaseRepository.Save();
            _accountBaseRepository.Save();
            _accountBookRepository.Save();

            // ViewModel operations
            var sortedBooks = _dataSorting.SortBooks(SortingEnums.SortingMethod.NOT_SET, SortingEnums.BookQuantity.NOT_SET, SortingEnums.Genre.NOT_SET);
            _libraryViewModel.DisplayBooks(sortedBooks);
        }

        public RentBookCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookModel> bookBaseRepository, IDataSorting dataSorting,
            IMappingService mappingService, IBaseRepository<AccountModel> accountBaseRepository, IAccountBookRepository accountBookRepository,
            IElementVisibilityService elementVisibilityService)
        {
            _libraryViewModel = libraryViewModel;
            _bookBaseRepository = bookBaseRepository;
            _dataSorting = dataSorting;
            _mappingService = mappingService;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            _elementVisibilityService = elementVisibilityService;
        }
    }
}
