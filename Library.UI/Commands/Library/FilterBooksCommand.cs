using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service.Library;
using Library.UI.Service.Validation;
using Library.UI.Stores;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.Commands.Library
{
    public class FilterBooksCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IElementVisibilityService _elementVisibilityService;

        private readonly BookStore _booksStore;

        private readonly IBookOperations _bookOperations;

        public FilterBooksCommand(LibraryViewModel libraryViewModel, IElementVisibilityService elementVisibilityService, 
            BookStore booksStore, IBookOperations bookOperations)
        {
            _libraryViewModel = libraryViewModel;
            _elementVisibilityService = elementVisibilityService;
            _booksStore = booksStore;
            _bookOperations = bookOperations;
        }

        public override void Execute(object parameter)
        {
            _libraryViewModel.BookList.Clear();
            _libraryViewModel.SelectedBook = _elementVisibilityService.SelectedBook;

            string searchBoxInput = _libraryViewModel.SearchBoxInput;
            if (string.IsNullOrEmpty(searchBoxInput) || string.IsNullOrWhiteSpace(searchBoxInput))
            {
                _libraryViewModel.DisplayBooks(_booksStore.CurrentBookList);
                _booksStore.FilteredBookList.Clear();
                return;
            }

            List<BookAccuracy> filteredBookList = _bookOperations.FilterBooks(searchBoxInput);
            _libraryViewModel.DisplayFilteredBooks(filteredBookList);

            // Refresh BookStore list
            List<BookModel> filteredBookStoreList = new List<BookModel>();
            foreach (BookAccuracy book in filteredBookList)
            {
                BookModel bookModel = new BookModel()
                {
                    BookId = book.Book.BookId,
                    Category = book.Book.Category,
                    Downloads = book.Book.Downloads,
                    Author = book.Book.Author,
                    AnyRequest = book.Book.AnyRequest,
                    BookLanguages = book.Book.BookLanguages,
                    BookGrade = book.Book.BookGrade,
                    Copies = book.Book.Copies,
                    Title = book.Book.Title,
                    IsRented = book.Book.IsRented,
                    AccountBooks = book.Book.AccountBooks
                };
                filteredBookStoreList.Add(bookModel);
            }
            
            _booksStore.FilteredBookList = filteredBookStoreList;
            _booksStore.OnBookListChanged();
        }
    }
}
