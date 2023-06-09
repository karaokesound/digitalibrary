﻿using Library.Models.Model;
using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Library;
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

        private readonly IBookOperations _dataSorting;

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
            if (selectedBook.Copies == 0)
            {
                string wMessage = "There are no copies of this book in the library. You can make a reservation for this book. " +
                    "We'll send you a message when it's available.";
                string wCaption = "Warning";
                MessageBox.Show(wMessage, wCaption);
                return;
            }

            if (loggedUser.MaxBookQntToRent == 0)
            {
                string wMessage = "You have rented 5 books.You have to return one of them to be able to rent another one.";
                string wCaption = "Warning";
                MessageBox.Show(wMessage, wCaption);
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
                    dbBook.Copies -= 1;
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
                    dbBook.Copies -= 1;
                    dbBook.AnyRequest = false;
                }
            }
            else if (dbBook.AnyRequest == true && loggedUser.AccountId != dbBook.RequestUserId)
            {
                string wMessage = "This book has reservation made by another user. We will get you know when it's available.";
                string wCaption = "Warning";
                MessageBox.Show(wMessage, wCaption); return;
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
                    dbBook.Copies -= 1;
                }
                else
                {
                    var existingRentedBook = _accountBookRepository.GetUserBookByID(loggedUser.AccountId, selectedBook.BookId);
                    if (existingRentedBook != null)
                    {
                        existingRentedBook.Quantity += 1;
                    }

                    loggedUser.MaxBookQntToRent -= 1;
                    dbBook.Copies -= 1;
                }
            }

            string sMessage = $"You have rented {selectedBook.Title}. Go to Profile to manage your books.";
            string sCaption = "Library";
            MessageBox.Show(sMessage, sCaption);

            bool isProfileListViewVisible = false;
            _elementVisibilityService.AdjustListViewVisibility(isProfileListViewVisible);

            _bookBaseRepository.Save();
            _accountBaseRepository.Save();
            _accountBookRepository.Save();

            // ViewModel operations
            var sortedBooks = _dataSorting.SortBooks(SortingEnums.SortingMethod.NOT_SET, SortingEnums.BookQuantity.NOT_SET, SortingEnums.Genre.NOT_SET,
                SortingEnums.AlphabeticalSorting.NOT_SET);
            _libraryViewModel.DisplayBooks(sortedBooks);
        }

        public RentBookCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookModel> bookBaseRepository, IBookOperations dataSorting,
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
