using Library.UI.Commands.Library;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using Library.UI.ViewModel.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class LibraryViewModel : BaseViewModel
    {
        private Guid _loggedAccountId;
        public Guid LoggedAccountId
        {
            get => _loggedAccountId;
            set
            {
                _loggedAccountId = value;
                OnPropertyChanged();
            }
        }

        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BookViewModel> _bookList;
        public ObservableCollection<BookViewModel> BookList
        {
            get => _bookList;
            set
            {
                _bookList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BookViewModel> _randomBookList;
        public ObservableCollection<BookViewModel> RandomBookList
        {
            get => _randomBookList;
            set
            {
                _randomBookList = value;
                OnPropertyChanged();
            }
        }

        private string _searchBoxInput;
        public string SearchBoxInput
        {
            get => _searchBoxInput;
            set
            {
                _searchBoxInput = value;
                OnPropertyChanged();
            }
        }

        private BookViewModel _selectedBook;
        public BookViewModel SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        private int _bookCounter;
        public int BookCounter
        {
            get => _bookCounter;
            set
            {
                _bookCounter = value;
                OnPropertyChanged();
            }
        }

        public SortingEnums SortingEnums { get; set; }

        public ICommand LibraryUpdateViewCommand { get; }

        public ICommand SortBooksCommand { get; }

        public ICommand FilterBooksCommand { get; }

        public ICommand RentBookCommand { get; }

        public ICommand ReturnBookCommand { get; }

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataSorting;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        public LibraryViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService,
            IDataSorting dataSorting, IUserAuthenticationService userAuthenticationService, IValidationService validationService, 
            IUserRepository userRepository, IBaseRepository<AccountModel> accountBaseRepository, IAccountBookRepository accountBookRepository)
        {
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataSorting = dataSorting;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            SortingEnums = new SortingEnums();
            BookList = new ObservableCollection<BookViewModel>();
            FilterBooksCommand = new FilterBooksCommand(this, _bookBaseRepository);
            RandomBookList = new ObservableCollection<BookViewModel>();
            SortBooksCommand = new SortBooksCommand(this, _dataSorting, SortingEnums);
            RentBookCommand = new RentBookCommand(this, _bookBaseRepository, _dataSorting, _mappingService, _accountBaseRepository, 
                _accountBookRepository);
            ReturnBookCommand = new ReturnBookCommand(this, _accountBaseRepository, _accountBookRepository, _mappingService, _bookBaseRepository,
                _dataSorting);
            LibraryUpdateViewCommand = new LibraryUpdateViewCommand(this, _bookBaseRepository, _mappingService, _dataSorting, _userAuthenticationService,
                _validationService, _userRepository, _accountBaseRepository, _accountBookRepository);
            GenerateRandomBooks();
            InterceptLoggedUserId();
        }

        public void DisplayBooks(List<BookModel> sortedBookList)
        {
            BookList.Clear();
            BookCounter = 0;
            _bookCounter = 0;

            foreach (var sortedBook in sortedBookList)
            {
                BookViewModel sortedBookVM = _mappingService.BookModelToViewModel(sortedBook, sortedBook.Author);

                _bookCounter++;
                sortedBookVM.BookCounter = _bookCounter;

                BookList.Add(sortedBookVM);
            }
        }

        public void GenerateRandomBooks()
        {
            var mostPopularBooks = _bookBaseRepository.GetAll().Where(book => book.Downloads > 10000).ToList();

            if (mostPopularBooks == null || mostPopularBooks.Count == 0) return;

            Random randomBook = new Random();

            for (int i = 0; i < 5; i++)
            {
                int rnd = randomBook.Next(mostPopularBooks.Count);
                RandomBookList.Add(_mappingService.BookModelToViewModel(mostPopularBooks[rnd], mostPopularBooks[rnd].Author));
            }
        }

        public void DisplayFilteredBooks(List<BookAccuracy> filteredBookList)
        {
            BookList.Clear();
            BookCounter = 0;
            _bookCounter = 0;

            foreach (var filteredBook in filteredBookList)
            {
                BookModel filteredBookModel = new BookModel()
                {
                    BookId = filteredBook.Book.BookId,
                    Title = filteredBook.Book.Title,
                    Quantity = filteredBook.Book.Quantity,
                    IsRented = filteredBook.Book.IsRented,
                    Author = filteredBook.Book.Author,
                    Category = filteredBook.Book.Category,
                    BookLanguages = filteredBook.Book.BookLanguages,
                };

                BookViewModel filteredBookVM = _mappingService.BookModelToViewModel(filteredBookModel, filteredBookModel.Author);

                _bookCounter++;
                filteredBookVM.BookCounter = _bookCounter;

                BookList.Add(filteredBookVM);
            }
        }

        private void InterceptLoggedUserId()
        {
            _loggedAccountId = _userAuthenticationService.UserId;
        }
    }
}
