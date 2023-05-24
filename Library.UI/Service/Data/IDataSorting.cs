using Library.UI.Model;
using Library.UI.ViewModel;
using System.Collections.Generic;

namespace Library.UI.Service.Data
{
    public interface IDataSorting
    {
        List<BookModel> SortBooks(LibraryViewModel.SortingMethod selectedMethod, 
            LibraryViewModel.BookQuantity selectedQuantity, LibraryViewModel.Genre selectedCategory);
    }
}
