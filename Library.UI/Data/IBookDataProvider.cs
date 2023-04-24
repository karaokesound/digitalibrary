using Library.UI.Model;
using System.Collections.Generic;

namespace Library.UI.Data
{
    public interface IBookDataProvider
    {
        public List<Book> GetAllBooks();
    }
}
