using Library.Models.Model;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.Service.Data
{
    public class DataSorting : IDataSorting
    {
        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IBaseRepository<AuthorModel> _authBaseRepository;

        private readonly IBaseRepository<LanguageModel> _lngBaseRepository;

        public DataSorting(IBaseRepository<BookModel> bookBaseRepository, IBaseRepository<AuthorModel> authBaseRepository,
       IBaseRepository<LanguageModel> lngBaseRepository)
        {
            _bookBaseRepository = bookBaseRepository;
            _authBaseRepository = authBaseRepository;
            _lngBaseRepository = lngBaseRepository;
        }

        public List<BookModel> DisplaySelectedNumberOfBooks(LibraryViewModel.SortingMethod selectedMethod, 
            LibraryViewModel.BookQuantity selectedQuantity)
        {
            List<BookModel> bookList = new List<BookModel>();
            bookList = _bookBaseRepository.GetAll().ToList();

            if (selectedQuantity == LibraryViewModel.BookQuantity.NOT_SET)
            {
                selectedQuantity = (LibraryViewModel.BookQuantity)999;
            }


            // app startup setup
            if (selectedMethod == LibraryViewModel.SortingMethod.NOT_SET && selectedQuantity == LibraryViewModel.BookQuantity.NOT_SET)
            {
                bookList = bookList.Take(bookList.Count).ToList();
            }

            // combobox
            else if (selectedMethod == LibraryViewModel.SortingMethod.NOT_SET)
            {
                bookList = bookList.Take((int)selectedQuantity).ToList();
            }
            else if (selectedMethod == LibraryViewModel.SortingMethod.Az)
            {
                bookList = bookList.OrderBy(b => b.Title).Take((int)selectedQuantity).ToList();
            }
            else if (selectedMethod == LibraryViewModel.SortingMethod.Downloads)
            {
                bookList = bookList.OrderByDescending(d => d.Downloads).Take((int)selectedQuantity).ToList();
            }

            return bookList;
        }
    }
}
