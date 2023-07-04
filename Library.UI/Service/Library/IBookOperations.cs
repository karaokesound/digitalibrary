using Library.UI.Model;
using Library.UI.ViewModel.Library;
using System.Collections.Generic;

namespace Library.UI.Service.Library
{
    public interface IBookOperations
    {
        List<BookModel> SortBooks(SortingEnums.SortingMethod selectedMethod, SortingEnums.BookQuantity selectedQuantity,
            SortingEnums.Genre selectedCategory, SortingEnums.AlphabeticalSorting selectedAlphabetical);

        List<BookAccuracy> FilterBooks(string searchBoxInput);
    }
}
