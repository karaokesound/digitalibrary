using Library.Models.Model;
using Library.Models.Model.many_to_many;
using Library.UI.Commands.Library;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Library;
using Library.UI.Service.Validation;
using Library.UI.Services;
using Library.UI.Stores;
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

        private List<BookModel> _filteredBookList;
        public List<BookModel> FilteredBookList
        {
            get => _filteredBookList;
            set
            {
                _filteredBookList = value;
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

        private BookViewModel _selectedBook;
        public BookViewModel SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                ShowBookGrade();
                OnPropertyChanged();

                //It is to keep focus on a selected book when clicking on a SearchBox
                if (value == null) return;
                _elementVisibilityService.ListViewSelectedBook(value);
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

        private bool _areBookDetailsVisible;
        public bool AreBookDetailsVisible
        {
            get => _areBookDetailsVisible;
            set
            {
                _areBookDetailsVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _areRatingStarsVisible;
        public bool AreRatingStarsVisible
        {
            get => _areRatingStarsVisible;
            set
            {
                _areRatingStarsVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _isBookGradeVisible;
        public bool IsBookGradeVisible
        {
            get => _isBookGradeVisible;
            set
            {
                _isBookGradeVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _isAzEnumSelected;
        public bool IsAzEnumSelected
        {
            get => _isAzEnumSelected;
            set
            {
                _isAzEnumSelected = value;
                OnPropertyChanged();
            }
        }

        public SortingEnums SortingEnums { get; set; }

        public ICommand SortBooksCommand { get; }

        public ICommand FilterBooksCommand { get; }

        public ICommand RentBookCommand { get; }

        public ICommand AddRequestCommand { get; }

        public ICommand LibraryReturnButtonCommand { get; }

        public ICommand BookDoubleClickCommand { get; }

        public ICommand AddGradeCommand { get; }

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IBookOperations _bookOperations;

        private readonly IUserAuthenticationService _userAuthService;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        private readonly IElementVisibilityService _elementVisibilityService;

        private readonly IBaseRepository<BookGradeModel> _bookgradeBaseRepository;

        private readonly IBaseRepository<GradeModel> _gradeBaseRepository;

        private readonly BookStore _bookStore;

        private List<BookModel> _requestedBooks;

        public LibraryViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService,
            IBookOperations bookOperations, IUserAuthenticationService userAuthenticationService, IValidationService validationService,
            IUserRepository userRepository, IBaseRepository<AccountModel> accountBaseRepository, IAccountBookRepository accountBookRepository,
            IElementVisibilityService elementVisibilityService, IBaseRepository<BookGradeModel> bookgradeBaseRepository,
            IBaseRepository<GradeModel> gradeBaseRepository, BookStore bookStore)
        {
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _bookOperations = bookOperations;
            _userAuthService = userAuthenticationService;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            _elementVisibilityService = elementVisibilityService;
            _bookgradeBaseRepository = bookgradeBaseRepository;
            _gradeBaseRepository = gradeBaseRepository;
            _bookStore = bookStore;
            _requestedBooks = new List<BookModel>();
            BookList = new ObservableCollection<BookViewModel>();
            FilteredBookList = new List<BookModel>();
            SortingEnums = new SortingEnums();
            AddGradeCommand = new AddGradeCommand(this, _bookgradeBaseRepository, _bookBaseRepository, _userAuthService,
                _gradeBaseRepository);
            BookDoubleClickCommand = new BookDoubleClickCommand(this, _userAuthService, _bookgradeBaseRepository);
            LibraryReturnButtonCommand = new LibraryReturnButtonCommand(this);
            SortBooksCommand = new SortBooksCommand(this, _bookOperations, SortingEnums);
            FilterBooksCommand = new FilterBooksCommand(this, _elementVisibilityService, _bookStore, _bookOperations);
            RandomBookList = new ObservableCollection<BookViewModel>();
            RentBookCommand = new RentBookCommand(this, _bookBaseRepository, _bookOperations, _mappingService,
                _accountBaseRepository, _accountBookRepository, _elementVisibilityService);
            AddRequestCommand = new AddRequestCommand(this, _bookBaseRepository, _mappingService);

            SetStartupBookList();
            GenerateRandomBooks();
            InterceptLoggedUserData();
            ShowBookGrade();
        }

        private void SetStartupBookList()
        {
            if (SearchBoxInput == null || SearchBoxInput.Length == 0)
            {
                _bookStore.CurrentBookList = _bookBaseRepository.GetAll().ToList();
                //_bookStore.OnStartupBookListChanged();
            }
            else _bookStore.CurrentBookList = _bookStore.CurrentBookList;
        }

        public void DisplayBooks(List<BookModel> sortedBookList)
        {
            BookList.Clear();
            BookCounter = 0;
            _bookCounter = 0;

            if (sortedBookList == null) return;

            foreach (var sortedBook in sortedBookList)
            {
                BookViewModel sortedBookVM = _mappingService.BookModelToViewModel(sortedBook, sortedBook.Author);

                // Counter is to place book in order in a listview
                _bookCounter++;
                sortedBookVM.BookCounter = _bookCounter;

                BookList.Add(sortedBookVM);
            }
        }

        public void DisplayFilteredBooks(List<BookAccuracy> filteredBookList)
        {
            FilteredBookList.Clear();
            BookList.Clear();
            BookCounter = 0;
            _bookCounter = 0;

            foreach (var filteredBook in filteredBookList)
            {
                BookModel filteredBookModel = new BookModel()
                {
                    BookId = filteredBook.Book.BookId,
                    Title = filteredBook.Book.Title,
                    Copies = filteredBook.Book.Copies,
                    Category = filteredBook.Book.Category,
                    Downloads = filteredBook.Book.Downloads,
                    IsRented = filteredBook.Book.IsRented,
                    AnyRequest = filteredBook.Book.AnyRequest,
                    Author = filteredBook.Book.Author,
                    BookLanguages = filteredBook.Book.BookLanguages,
                };

                BookViewModel filteredBookVM = _mappingService.BookModelToViewModel(filteredBookModel, filteredBookModel.Author);
                FilteredBookList.Add(filteredBookModel);

                // Counter is to place book in order in a listview
                _bookCounter++;
                filteredBookVM.BookCounter = _bookCounter;

                BookList.Add(filteredBookVM);
            }
        }

        public void ShowBookGrade()
        {
            if (SelectedBook == null) return;

            List<BookGradeModel> selectedBookgrades = new List<BookGradeModel>();
            selectedBookgrades = _bookgradeBaseRepository.GetAll().Where(b => b.BookId == SelectedBook.BookId).ToList();

            decimal average = 0;

            if (selectedBookgrades.Count() == 0)
            {
                average = 0;
                SelectedBook.BookGrade = "No grades yet";
                AreRatingStarsVisible = true;
                return;
            }

            int gradesSum = 0;

            foreach (var bookGrade in selectedBookgrades)
            {
                var gradeModel = _gradeBaseRepository.GetByID(bookGrade.GradeId);
                gradesSum += gradeModel.Grade;
            }

            average = (decimal)gradesSum / selectedBookgrades.Count;

            SelectedBook.BookGrade = average.ToString("0.00");

            // Adjust rating stars visibility
            IEnumerable<BookGradeModel> userRate = _bookgradeBaseRepository.GetAll().Where(a => (a.GradeAuthorId == LoggedAccountId)
            && (a.BookId == SelectedBook.BookId));

            if (userRate != null && userRate.Count() != 0)
            {
                AreRatingStarsVisible = false;
                return;
            }
            AreRatingStarsVisible = true;
        }

        private void GenerateRandomBooks()
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

        private void InterceptLoggedUserData()
        {
            _loggedAccountId = _userAuthService.UserId;
            _requestedBooks = _userAuthService._requestedBooks;
        }
    }
}
