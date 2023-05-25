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

        public DataSorting(IBaseRepository<BookModel> bookBaseRepository)
        {
            _bookBaseRepository = bookBaseRepository;
        }

        public List<BookModel> SortBooks(LibraryViewModel.SortingMethod selectedMethod,
            LibraryViewModel.BookQuantity selectedQuantity, LibraryViewModel.Genre selectedCategory)
        {
            if (selectedQuantity == LibraryViewModel.BookQuantity.NOT_SET)
            {
                selectedQuantity = (LibraryViewModel.BookQuantity)999;
            }

            List<BookModel> bookList = new List<BookModel>();

            if (selectedCategory == LibraryViewModel.Genre.NOT_SET)
            {
                bookList = _bookBaseRepository.GetAll().ToList();
            }
            else
            {
                bookList = _bookBaseRepository.GetAll().Where(c => c.Category == string.Join(" ", selectedCategory.ToString().Split('_'))).ToList();
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
