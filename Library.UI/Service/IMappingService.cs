using Library.UI.Model;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;

namespace Library.UI.Service
{
    public interface IMappingService
    {
        public BookViewModel BookModelToViewModel(BookModel book);

        public BookModel BookViewModelToModel(BookViewModel bookVM);

        public UserViewModel UserModelToViewModel(UserModel signUp);

        public UserModel UserViewModelToModel(UserViewModel signUpVM);
    }
}
