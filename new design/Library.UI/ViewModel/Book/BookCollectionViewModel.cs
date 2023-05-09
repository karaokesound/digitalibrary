using Library.UI.Command;
using Library.UI.Data;
using Library.UI.Model;
using Library.UI.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class BookCollectionViewModel : BaseViewModel
    {
        private BookViewModel? _selectedBook;
        public BookViewModel? SelectedBook
        {
            get => _selectedBook;
            set 
            { 
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        public BookViewModel NewBookVM { get; set; }

        public ObservableCollection<BookViewModel> Books { get; }

        public ICommand AddBookCommand { get; }

        private readonly IBookDataProvider _bookDataProvider;

        public BookCollectionViewModel(IBookDataProvider bookDataProvider)
        {
            Books = new ObservableCollection<BookViewModel>();
            NewBookVM = new BookViewModel();
            AddBookCommand = new AddBookCommand(this);
            _bookDataProvider = bookDataProvider;
            GetAllBooks();
        }

        public void GetAllBooks()
        {
            if (Books.Any())
            {
                return;
            }

            List<BookModel> books = _bookDataProvider.GetAllBooks();
            if (books != null)
            {
                foreach (BookModel book in books)
                {
                    BookViewModel bookVM = MappingService.BookModelToViewModel(book);
                    Books.Add(bookVM);
                }
            }
        }

        public void AddBook(BookModel newBook)
        {
            BookViewModel newBookVM = MappingService.BookModelToViewModel(newBook);
            Books.Add(newBookVM);
        }
    }
}
