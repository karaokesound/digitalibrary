using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
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

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        public override void Execute(object parameter)
        {
            _libraryViewModel.BookList.Clear();

            string searchText = _libraryViewModel.SearchBoxInput;

            if (string.IsNullOrEmpty(searchText) || string.IsNullOrWhiteSpace(searchText))
            {
                _libraryViewModel.DisplayBooks(_bookBaseRepository.GetAll().ToList());
                return;
            }

            List<BookModel> matchingBooks = _bookBaseRepository.GetAll().Where(b => b.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            List<BookAccuracy> accurateBooks = new List<BookAccuracy>();

            foreach (BookModel book in matchingBooks)
            {
                string lowercaseTitle = book.Title.ToLower();

                int index = lowercaseTitle.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);

                if (index > 0)
                {
                    accurateBooks.Add(new BookAccuracy() { Book = book, Accuracy = index });
                }
            }

            _libraryViewModel.DisplayFilteredBooks(accurateBooks);
        }

        public FilterBooksCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookModel> bookBaseRepository)
        {
            _libraryViewModel = libraryViewModel;
            _bookBaseRepository = bookBaseRepository;
        }
    }
}
