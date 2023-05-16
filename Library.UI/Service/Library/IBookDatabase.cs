using Library.UI.Model;
using Library.UI.Services;

namespace Library.UI.Service
{
    public interface IBookDatabase : IBaseRepository<BookModel>
    {
        public void InsertsBooksToDatabase();
    }
}
