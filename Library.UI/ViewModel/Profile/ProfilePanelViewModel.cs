using Library.Models.Model;
using Library.UI.Commands.Profile;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Validation;
using Library.UI.Services;
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

        private bool _isManagePanelVisible = false;
        public bool IsManagePanelVisible
        {
            get => _isManagePanelVisible;
            set 
            { 
                _isManagePanelVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _isGuidePanelVisible = false;
        public bool IsGuidePanelVisible
        {
            get => _isGuidePanelVisible;
            set
            {
                _isGuidePanelVisible = value;
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

        public ICommand ManagePanelCommand { get; }

        public ICommand GuidePanelCommand { get; }

        public ICommand ReturnBookCommand { get; }

        public ICommand ReturnButtonCommand { get; }

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        private readonly IElementVisibilityService _elementVisibilityService;

        private List<BookModel> _requestedBooks;

        public ProfilePanelViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService,
            IUserAuthenticationService userAuthenticationService, IBaseRepository<AccountModel> accountBaseRepository, 
            IAccountBookRepository accountBookRepository, IElementVisibilityService elementVisibilityService)
        {
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _userAuthenticationService = userAuthenticationService;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            _elementVisibilityService = elementVisibilityService;
            _requestedBooks = new List<BookModel>();
            UserRentedBooks = new ObservableCollection<UserBooksData>();
            ManagePanelCommand = new ManagePanelCommand(this);
            GuidePanelCommand = new GuidePanelCommand(this);
            ReturnButtonCommand = new ReturnButtonCommand(this);
            ReturnBookCommand = new ReturnBookCommand(this, _accountBaseRepository, _accountBookRepository, _mappingService, _bookBaseRepository);
            TakeLoggedUserData();
        }

        public void RemoveUserRentedBook(BookModel removingBook)
        {
            var matchingBook = UserRentedBooks.FirstOrDefault(b => b.Book.BookId == removingBook.BookId);

            if (matchingBook != null)
            {
                if (matchingBook.AccountBook.Quantity >= 1)
                {
                    matchingBook.AccountBook.Quantity = matchingBook.AccountBook.Quantity;
                }
                else UserRentedBooks.Remove(matchingBook);
            }

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
