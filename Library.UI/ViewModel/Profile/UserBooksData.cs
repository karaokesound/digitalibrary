using Library.Models.Model;
using Library.UI.ViewModel.Library;

namespace Library.UI.ViewModel.Profile
{
    public class UserBooksData : BaseViewModel
    {
        public BookViewModel Book { get; set; }
        public AccountBookModel AccountBook { get; set; }
    }
}
