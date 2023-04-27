using Library.UI.Model;
using Library.UI.ViewModel;

namespace Library.UI.Services
{
    public static class MappingService
    {
        // BOOKS MAPPING SERVICE //
        public static BookViewModel BookModelToViewModel (BookModel bookModel)
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

        public static BookModel BookViewModelToModel (BookViewModel bookViewModel)
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

        // SIGN UP MAPPING SERVICE //
        public static SignUpViewModel SignUpModelToViewModel(SignUpModel signUp)
        {
            return new SignUpViewModel()
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                City = signUp.City,
                Library = signUp.Library,
            };
        }

        public static SignUpModel SignUpViewModelToModel(SignUpViewModel signUpVM)
        {
            return new SignUpModel()
            {
                FirstName = signUpVM.FirstName,
                LastName = signUpVM.LastName,
                Email = signUpVM.Email,
                City = signUpVM.City,
                Library = signUpVM.Library,
            };
        }
    }
}
