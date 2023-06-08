using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
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

            parameter = _libraryViewModel.SearchBoxInput;
            if (string.IsNullOrEmpty((string)parameter) || string.IsNullOrWhiteSpace((string)parameter))
            {
                _libraryViewModel.DisplayBooks(_bookBaseRepository.GetAll().ToList());
                return;
            }

            char[] arrayParameter = parameter.ToString().ToArray();

            List<BookModel> matchingBooks = _bookBaseRepository.GetAll().Where(b => b.Title.Contains((string)parameter)).ToList();
            List<BookAccuracy> accurateBooks = new List<BookAccuracy>();

            int accuracy = 0;

            foreach (BookModel book in matchingBooks)
            {
                int counter = book.Title.Count();
                bool bookAdded = false;

                for (int p = 0; p < arrayParameter.Count(); p++)
                {
                    for (int i = 0; i < counter; i++)
                    {
                        if (book.Title[i] == arrayParameter[p])
                        {
                            accuracy = i;

                            if (accurateBooks.GroupBy(t => t.Book.BookId).Any(g => g.Count() > 1))
                            {
                                break;
                            }
                            else
                            {
                                accurateBooks.Add(new BookAccuracy() { Book = book, Accuracy = i });
                                bookAdded = true;
                                break;
                            }
                        }
                    }

                    if (bookAdded)
                    {
                        break;
                    }
                }

                accurateBooks = accurateBooks.OrderBy(b => b.Accuracy).ThenBy(t => t.Book.Title).ToList();

                _libraryViewModel.DisplayFilteredBooks(accurateBooks);
            }
        }

        public FilterBooksCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookModel> bookBaseRepository)
        {
            _libraryViewModel = libraryViewModel;
            _bookBaseRepository = bookBaseRepository;
        }
    }
}
