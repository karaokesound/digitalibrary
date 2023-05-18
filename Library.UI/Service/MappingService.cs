using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.API.Dto;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System.Threading.Tasks;

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
                Languages = book.Languages,
                Author = book.Author,
            };
        }

        public BookModel BookViewModelToModel(BookViewModel bookVM)
        {
            return new BookModel
            {
                BookId = bookVM.BookId,
                Title = bookVM.Title,
                Category = bookVM.Category,
                Languages = bookVM.Languages,
                Author = bookVM.Author,
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
