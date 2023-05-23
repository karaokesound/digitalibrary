using Library.Models.Model;
using Library.UI.Model;
using Library.UI.Services;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.Service.Data
{
    public class DataFiltering : IDataFiltering
    {
        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IBaseRepository<AuthorModel> _authBaseRepository;

        private readonly IBaseRepository<LanguageModel> _lngBaseRepository;

        public List<BookModel> _aplhabeticalBookList;

        public DataFiltering(IBaseRepository<BookModel> bookBaseRepository, IBaseRepository<AuthorModel> authBaseRepository,
       IBaseRepository<LanguageModel> lngBaseRepository)
        {
            _bookBaseRepository = bookBaseRepository;
            _authBaseRepository = authBaseRepository;
            _lngBaseRepository = lngBaseRepository;
            _aplhabeticalBookList = new List<BookModel>();
        }

        public List<BookModel> SortBooksAlphabetical()
        {
            var bookList = _bookBaseRepository.GetAll().ToList();

            return _aplhabeticalBookList = bookList.OrderBy(b => b.Title).ToList();
        }

        public List<BookModel> DisplayInsertedNumberOfBooks()
        {
            // This method should be used by herself or in combination with a filter method.
            // For example: SortBooksAlphabetical() => DisplayInsertedNumberOfBooks(). This will cause showing (...)
            // of books ordered alphabetical.

            var bookList = SortBooksAlphabetical();
            List<BookModel> shortenedList = new List<BookModel>();
            return shortenedList = bookList.Take(10).ToList();
        }
    }
}
