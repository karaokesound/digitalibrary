using Library.UI.Model;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;

namespace Library.UI.Service
{
    public interface IMappingService
    {
        public BookViewModel BookModelToViewModel(BookModel book, AuthorModel author);

        public BookModel BookViewModelToModel(BookViewModel bookVM, AuthorViewModel authorVM);

        public AccountViewModel UserModelToViewModel(AccountModel signUp);

        public AccountModel UserViewModelToModel(AccountViewModel signUpVM);
    }
}
