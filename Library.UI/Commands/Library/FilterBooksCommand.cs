using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service.Library;
using Library.UI.Service.Validation;
using Library.UI.Stores;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System.Collections.Generic;

namespace Library.UI.Commands.Library
{
    public class FilterBooksCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IElementVisibilityService _elementVisibilityService;

        private readonly BookStore _bookStore;

        private readonly IBookOperations _bookOperations;

        public FilterBooksCommand(LibraryViewModel libraryViewModel, IElementVisibilityService elementVisibilityService, 
            BookStore bookStore, IBookOperations bookOperations)
        {
            _libraryViewModel = libraryViewModel;
            _elementVisibilityService = elementVisibilityService;
            _bookOperations = bookOperations;
            _bookStore = bookStore;
        }

        public override void Execute(object parameter)
        {
            _libraryViewModel.BookList.Clear();
            _libraryViewModel.SelectedBook = _elementVisibilityService.SelectedBook;

            string searchBoxInput = _libraryViewModel.SearchBoxInput;
            if (string.IsNullOrEmpty(searchBoxInput) || string.IsNullOrWhiteSpace(searchBoxInput))
            {
                _libraryViewModel.DisplayBooks(_bookStore.CurrentBookList);
                _bookStore.FilteredBookList.Clear();
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
            
            _bookStore.FilteredBookList = filteredBookStoreList;
            _bookStore.OnBookListChanged();
        }
    }
}
