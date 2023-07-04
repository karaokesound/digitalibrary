using Library.UI.Command;
using Library.UI.Model;
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

        private readonly BooksStore _booksStore;

        public FilterBooksCommand(LibraryViewModel libraryViewModel, IElementVisibilityService elementVisibilityService, 
            BooksStore booksStore)
        {
            _libraryViewModel = libraryViewModel;
            _elementVisibilityService = elementVisibilityService;
            _booksStore = booksStore;
        }

        public override void Execute(object parameter)
        {
            _libraryViewModel.BookList.Clear();
            _libraryViewModel.SelectedBook = _elementVisibilityService.SelectedBook;

            string searchText = _libraryViewModel.SearchBoxInput;

            if (string.IsNullOrEmpty(searchText) || string.IsNullOrWhiteSpace(searchText))
            {
                _libraryViewModel.DisplayBooks(_booksStore.CurrentBookList);
                _booksStore.FilteredBookList.Clear();
                return;
            }

            List<BookModel> matchingBooks = _booksStore.CurrentBookList.Where(b => b.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            List<BookAccuracy> accurateBooks = new List<BookAccuracy>();

            foreach (BookModel book in matchingBooks)
            {
                string lowercaseTitle = book.Title.ToLower();

                int index = lowercaseTitle.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);

                if (index >= 0)
                {
                    accurateBooks.Add(new BookAccuracy() { Book = book, Accuracy = index });
                }
            }
            _libraryViewModel.DisplayFilteredBooks(accurateBooks);


            List<BookModel> temporaryList = new List<BookModel>();
            foreach (BookAccuracy book in accurateBooks)
            {
                BookModel tempBook = new BookModel()
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
                temporaryList.Add(tempBook);
            }

            _booksStore.FilteredBookList = temporaryList;
            _booksStore.OnBookListChanged();
        }
    }
}
