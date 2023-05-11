using Library.UI.Model;
using Library.UI.ViewModel;

namespace Library.UI.Service
{
    public interface IMappingService
    {
        public BookViewModel BookModelToViewModel(BookModel bookModel);

        public BookModel BookViewModelToModel(BookViewModel bookViewModel);

        public UserViewModel UserModelToViewModel(UserModel signUp);

        public UserModel UserViewModelToModel(UserViewModel signUpVM);
    }
}
