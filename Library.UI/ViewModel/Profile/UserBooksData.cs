using Library.Models.Model;
using Library.UI.ViewModel.Library;

namespace Library.UI.ViewModel.Profile
{
    public class UserBooksData : BaseViewModel
    {
        // This model exists for the ProfilePanelViewModel method RemoveUserRentedBook()
        public BookViewModel Book { get; set; }
        public AccountBookModel AccountBook { get; set; }
    }
}
