using Library.UI.Model;
using Library.UI.ViewModel.Library;
using System.Collections.Generic;

namespace Library.UI.Stores
{
    public class BooksStoreModel
    {
        public List<BookModel> CurrentBookList { get; set; }
        public SortingEnums.SortingMethod CurrentMethod { get; set; }
        public SortingEnums.BookQuantity CurrentQuantity { get; set; }
        public SortingEnums.Genre CurrentCategory { get; set; }
        public SortingEnums.AlphabeticalSorting CurrentAlphabMethod { get; set; }
    }
}
