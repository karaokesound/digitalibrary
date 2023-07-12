using Library.UI.Model;

namespace Library.UI.ViewModel.Library
{
    public class BookAccuracy
    {
        // This model exists for the FilterBooksCommand
        public BookModel Book { get; set; }
        public int Accuracy { get; set; }
    }
}
