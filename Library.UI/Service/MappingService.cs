using Library.UI.Model;
using Library.UI.Service;
using Library.UI.ViewModel;

namespace Library.UI.Services
{
    public class MappingService : IMappingService
    {
        // BOOKS MAPPING SERVICE //
        public BookViewModel BookModelToViewModel (BookModel bookModel)
        {
            BookViewModel bookViewModel = new BookViewModel()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Volume = bookModel.Volume,
                Pages = bookModel.Pages,
            };
            return bookViewModel;
        }

        public BookModel BookViewModelToModel (BookViewModel bookViewModel)
        {
            BookModel bookModel = new BookModel()
            {
                Id = bookViewModel.Id,
                Title = bookViewModel.Title,
                Volume = bookViewModel.Volume,
                Pages = bookViewModel.Pages,
            };
            return bookModel;
        }

        // USER MAPPING SERVICE //
        public UserViewModel UserModelToViewModel(UserModel signUp)
        {
            return new UserViewModel(_validationService)
            {
                Id = signUp.Id,
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
                Id = signUpVM.Id,
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
