using Library.Models.Model;
using Library.Models.Model.many_to_many;
using Library.UI.Commands.Library;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Service.Validation;
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

        private bool _areRatingStarsVisible = false;
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

        private float _bookGrade;
        public float BookGrade
        {
            get => _bookGrade;
            set 
            { 
                _bookGrade = value;
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

        public ICommand YesNoButtonCommand { get; }

        public ICommand AddGradeCommand { get; }

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataSorting;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        private readonly IElementVisibilityService _elementVisibilityService;

        private readonly IBaseRepository<BookGradeModel> _bookgradeBaseRepository;

        private readonly IBaseRepository<GradeModel> _gradeBaseRepository;

        private readonly NavigationStore _navigationStore;

        private List<BookModel> _requestedBooks;

        public LibraryViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService,
            IDataSorting dataSorting, IUserAuthenticationService userAuthenticationService, IValidationService validationService, 
            IUserRepository userRepository, IBaseRepository<AccountModel> accountBaseRepository, IAccountBookRepository accountBookRepository,
            IElementVisibilityService elementVisibilityService, IBaseRepository<BookGradeModel> bookgradeBaseRepository, 
            IBaseRepository<GradeModel> gradeBaseRepository, NavigationStore navigationStore)
        {
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataSorting = dataSorting;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            _elementVisibilityService = elementVisibilityService;
            _bookgradeBaseRepository = bookgradeBaseRepository;
            _gradeBaseRepository = gradeBaseRepository;
            _navigationStore = navigationStore;
            _requestedBooks = new List<BookModel>();
            SortingEnums = new SortingEnums();
            BookList = new ObservableCollection<BookViewModel>();
            AddGradeCommand = new AddGradeCommand(this, _bookgradeBaseRepository, _bookBaseRepository, _userAuthenticationService, 
                _gradeBaseRepository);
            YesNoButtonCommand = new YesNoButtonCommand(this);
            BookDoubleClickCommand = new BookDoubleClickCommand(this, _elementVisibilityService, _bookgradeBaseRepository);
            LibraryReturnButtonCommand = new LibraryReturnButtonCommand(this, _elementVisibilityService);
            FilterBooksCommand = new FilterBooksCommand(this, _bookBaseRepository);
            RandomBookList = new ObservableCollection<BookViewModel>();
            SortBooksCommand = new SortBooksCommand(this, _dataSorting, SortingEnums);
            RentBookCommand = new RentBookCommand(this, _bookBaseRepository, _dataSorting, _mappingService, _accountBaseRepository, 
                _accountBookRepository, _elementVisibilityService);
            AddRequestCommand = new AddRequestCommand(this, _bookBaseRepository, _mappingService);
            GenerateRandomBooks();
            InterceptLoggedUserData();
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
                    Copies = filteredBook.Book.Copies,
                    Category = filteredBook.Book.Category,
                    Downloads = filteredBook.Book.Downloads,
                    IsRented = filteredBook.Book.IsRented,
                    AnyRequest = filteredBook.Book.AnyRequest,
                    Author = filteredBook.Book.Author,
                    BookLanguages = filteredBook.Book.BookLanguages,
                };

                BookViewModel filteredBookVM = _mappingService.BookModelToViewModel(filteredBookModel, filteredBookModel.Author);

                _bookCounter++;
                filteredBookVM.BookCounter = _bookCounter;

                BookList.Add(filteredBookVM);
            }
        }

        public void ShowBookGrade()
        {
            List<BookGradeModel> selectedBookgrades = new List<BookGradeModel>();

            selectedBookgrades = _bookgradeBaseRepository.GetAll().Where(b => b.BookId == SelectedBook.BookId).ToList();

            float average = 0;

            if (selectedBookgrades.Count() == 0)
            {
                average = 0;
                BookGrade = average;
                return;
            }

            List<GradeModel> grades = new List<GradeModel>();
            List<int> bookGrades = new List<int>();

            int gradesSum = 0;

            foreach (var bookGrade in selectedBookgrades)
            {
                grades.Add(_gradeBaseRepository.GetByID(bookGrade.GradeId));
            }

            foreach (var g in grades)
            {
                gradesSum += g.Grade;
            }

            average = gradesSum / selectedBookgrades.Count();

            BookGrade = average;
        }

        private void InterceptLoggedUserData()
        {
            _loggedAccountId = _userAuthenticationService.UserId;
            _requestedBooks = _userAuthenticationService._requestedBooks;
        }
    }
}
