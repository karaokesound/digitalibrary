using Library.UI.Model;
using System.Collections.Generic;

namespace Library.UI.Service.Data
{
    public interface IDataSorting
    {
        List<BookModel> SortBooksAlphabetically();

        List<BookModel> DisplayInsertedNumberOfBooks();

        List<BookModel> DisplayAllBooks();
    }
}
