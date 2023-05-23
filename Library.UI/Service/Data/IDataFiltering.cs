using Library.UI.Model;
using System.Collections.Generic;

namespace Library.UI.Service.Data
{
    public interface IDataFiltering
    {
        List<BookModel> SortBooksAlphabetical();

        List<BookModel> DisplayInsertedNumberOfBooks();
    }
}
