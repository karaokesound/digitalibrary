using Library.UI.Model;
using Library.UI.Service;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;

namespace Library.UI.Services
{
    public class MappingService : IMappingService
    {
        // BOOK MAPPING SERVICE //
        public BookViewModel BookModelToViewModel(BookModel book)
        {
            return new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                Category = book.Category,
                Pages = book.Pages,
                Authors = book.Authors,
            };
        }

        public BookModel BookViewModelToModel(BookViewModel bookVM)
        {
            return new BookModel
            {
                BookId = bookVM.BookId,
                Title = bookVM.Title,
                Category = bookVM.Category,
                Pages = bookVM.Pages,
                Authors = bookVM.Authors,
            };
        }

        // USER MAPPING SERVICE //
        public UserViewModel UserModelToViewModel(UserModel signUp)
        {
            return new UserViewModel(_validationService)
            {
                UserId = signUp.UserId,
                Username = signUp.Username,
                Password = signUp.Password,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                City = signUp.City,
                Library = signUp.Library,
            };
        }

        public UserModel UserViewModelToModel(UserViewModel signUpVM)
        {
            return new UserModel()
            {
                UserId = signUpVM.UserId,
                Username = signUpVM.Username,
                Password = signUpVM.Password,
                FirstName = signUpVM.FirstName,
                LastName = signUpVM.LastName,
                Email = signUpVM.Email,
                City = signUpVM.City,
                Library = signUpVM.Library,
            };
        }

        private readonly IValidationService _validationService;

        public MappingService(IValidationService validationService)
        {
            _validationService = validationService;
        }
    }
}
