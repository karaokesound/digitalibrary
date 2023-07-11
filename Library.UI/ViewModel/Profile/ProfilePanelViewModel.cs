using Library.Models.Model;
using Library.Models.Model.many_to_many;
using Library.UI.Commands.Profile;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Library;
using Library.UI.Service.Validation;
using Library.UI.Services;
using Library.UI.Store;
using Library.UI.ViewModel.Profile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class ProfilePanelViewModel : BaseViewModel
    {
        private AccountModel _loggedUser;
        public AccountModel LoggedUser
        {
            get => _loggedUser;
            set
            {
                _loggedUser = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<UserBooksData> _userRentedBooks;
        public ObservableCollection<UserBooksData> UserRentedBooks
        {
            get => _userRentedBooks;
            set
            {
                _userRentedBooks = value;
                OnPropertyChanged();
            }
        }

        private UserBooksData _selectedBook;
        public UserBooksData SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        private bool _isReturnsPanelVisible = false;
        public bool IsReturnsPanelVisible
        {
            get => _isReturnsPanelVisible;
            set 
            { 
                _isReturnsPanelVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _isListViewVisible = false;
        public bool IsListViewVisible
        {
            get => _isListViewVisible;
            set
            {
                _isListViewVisible = value;
                IsNoRentedBooksPanelVisible = !value;
                OnPropertyChanged();
                OnPropertyChanged("IsNoRentedBooksPanelVisible");
            }
        }

        private int _noOfRentedBooks;
        public int NoOfRentedBooks
        {
            get => _noOfRentedBooks;
            set 
            { 
                _noOfRentedBooks = value;
                NoOfLeftedBooksToRent = 5 - value;
                OnPropertyChanged();
                OnPropertyChanged("NoOfLeftedBooksToRent");
            }
        }

        public int NoOfLeftedBooksToRent { get; set; }
        public bool IsNoReqBooksPanelVisible { get; set; }
        public bool IsNoRentedBooksPanelVisible { get; set; }

        public ICommand ReturnBookCommand { get; }

        public ICommand ReturnsPanelCommand { get; }

        public ICommand ReturnButtonCommand { get; }

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IBookOperations _dataSorting;

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

        public ProfilePanelViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService, IBookOperations dataSorting,
            IUserAuthenticationService userAuthenticationService, IValidationService validationService, IUserRepository userRepository,
            IBaseRepository<AccountModel> accountBaseRepository, IAccountBookRepository accountBookRepository, IElementVisibilityService elementVisibilityService,
            IBaseRepository<BookGradeModel> bookgradeBaseRepository, IBaseRepository<GradeModel> gradeBaseRepository, NavigationStore navigationStore)
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
            UserRentedBooks = new ObservableCollection<UserBooksData>();
            ReturnButtonCommand = new ReturnButtonCommand(this, _elementVisibilityService);
            ReturnsPanelCommand = new ReturnsPanelCommand(this, _elementVisibilityService);
            ReturnBookCommand = new ReturnBookCommand(this, _accountBaseRepository, _accountBookRepository, _mappingService, _bookBaseRepository);
            TakeLoggedUserData();
        }

        public void RemoveUserRentedBook(BookModel removingBook)
        {
            var matchingBook = UserRentedBooks.FirstOrDefault(b => b.Book.BookId == removingBook.BookId);
            UserRentedBooks.Remove(matchingBook);

            if (UserRentedBooks.Count == 0)
            {
                bool isListViewVisible = false;
                _elementVisibilityService.AdjustListViewVisibility(isListViewVisible);
                IsListViewVisible = _elementVisibilityService.IsListViewVisible;
            }
        }

        public void TakeLoggedUserData()
        {
            if (_userAuthenticationService.LoggedUser == null) return;

            UserRentedBooks.Clear();

            LoggedUser = _userAuthenticationService.LoggedUser;
            IsListViewVisible = true;

            List<AccountBookModel> userRentedBooks = _accountBookRepository.GetAllUserBooksByID(LoggedUser.AccountId).ToList();
            List<Guid> userRentedBooksID = userRentedBooks.Select(b => b.BookId).ToList();

            NoOfRentedBooks = userRentedBooks.Count();
            
            var books = _userAuthenticationService._requestedBooks;

            foreach (var book in books)
            {
                string message = $"You made a reservation for {book.Title}. It is available now. Go to library to rent the book";
                string caption = "Reservation";
                if (book.Copies == 1 && book.AnyRequest == true) MessageBox.Show(message, caption);
                book.AnyRequest = false;
            }

            // Shows books in ListView in ProfilePanelView.xaml
            foreach (var book in userRentedBooks)
            {
                BookModel bookModel = _bookBaseRepository.GetByID(book.BookId);

                UserRentedBooks.Add(new UserBooksData()
                {
                    Book = _mappingService.BookModelToViewModel(bookModel, bookModel.Author),
                    AccountBook = book
                });
            }

            if (UserRentedBooks.Count == 0)
            {
                bool isListViewVisible = false;
                _elementVisibilityService.AdjustListViewVisibility(isListViewVisible);
                IsListViewVisible = _elementVisibilityService.IsListViewVisible;
            }
        }
    }
}
