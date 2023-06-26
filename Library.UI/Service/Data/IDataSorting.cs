using Library.UI.Model;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System.Collections.Generic;

namespace Library.UI.Service.Data
{
    public interface IDataSorting
    {
        List<BookModel> SortBooks(SortingEnums.SortingMethod selectedMethod, SortingEnums.BookQuantity selectedQuantity,
            SortingEnums.Genre selectedCategory, SortingEnums.AlphabeticalSorting selectedAlphabetical);
    }
}
