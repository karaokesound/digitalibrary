using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.SignUp;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;

namespace Library.UI.Services
{
    public class MappingService : IMappingService
    {
        // BOOK MAPPING SERVICE //
        public BookViewModel BookModelToViewModel(BookModel book, AuthorModel author)
        {
            return new BookViewModel()
            {
                BookId = book.BookId,
                Title = book.Title,
                Copies = book.Copies,
                IsRented = book.IsRented,
                AnyRequest = book.AnyRequest,
                Category = book.Category,
                Downloads = book.Downloads,
                BookLanguages = book.BookLanguages,
                Author = new AuthorViewModel()
                {
                    AuthorId = author.AuthorId,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    BirthYear = author.BirthYear,
                    DeathYear = author.DeathYear
                }
            };
        }

        public BookModel BookViewModelToModel(BookViewModel bookVM, AuthorViewModel authorVM)
        {
            return new BookModel()
            {
                BookId = bookVM.BookId,
                Title = bookVM.Title,
                Copies = bookVM.Copies,
                IsRented = bookVM.IsRented,
                AnyRequest = bookVM.AnyRequest,
                Category = bookVM.Category,
                Downloads = bookVM.Downloads,
                BookLanguages = bookVM.BookLanguages,
                Author = new AuthorModel()
                {
                    AuthorId = authorVM.AuthorId,
                    FirstName = authorVM.FirstName,
                    LastName = authorVM.LastName,
                    BirthYear = authorVM.BirthYear,
                    DeathYear = authorVM.DeathYear
                }
            };
        }

        // USER MAPPING SERVICE //
        public AccountViewModel UserModelToViewModel(AccountModel signUp)
        {
            return new AccountViewModel(_notificationService)
            {
                UserId = signUp.AccountId,
                Username = signUp.Username,
                Password = signUp.Password,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                City = signUp.City,
                Library = signUp.Library,
            };
        }

        public AccountModel UserViewModelToModel(AccountViewModel signUpVM)
        {
            return new AccountModel()
            {
                AccountId = signUpVM.UserId,
                Username = signUpVM.Username,
                Password = signUpVM.Password,
                FirstName = signUpVM.FirstName,
                LastName = signUpVM.LastName,
                Email = signUpVM.Email,
                City = signUpVM.City,
                Library = signUpVM.Library,
            };
        }

        private readonly INotificationService _notificationService;

        public MappingService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
    }
}
