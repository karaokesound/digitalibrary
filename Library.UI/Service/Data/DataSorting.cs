using Library.UI.Model;
using Library.UI.Services;
using Library.UI.Stores;
using Library.UI.ViewModel.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.Service.Data
{
    public class DataSorting : IDataSorting
    {
        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IBaseRepository<AuthorModel> _authBaseRepository;

        private readonly SortingEnums _sortingEnums;

        private readonly BooksStore _booksStore;

        public List<BookModel> _currentBookList;

        public DataSorting(IBaseRepository<BookModel> bookBaseRepository, IBaseRepository<AuthorModel> authBaseRepository,
          SortingEnums sortingEnums, BooksStore booksStore)
        {
            _bookBaseRepository = bookBaseRepository;
            _authBaseRepository = authBaseRepository;
            _sortingEnums = sortingEnums;
            _currentBookList = new List<BookModel>();
            _booksStore = booksStore;

            _booksStore.BookListChanged += OnBookListChanged;
        }

        private void OnBookListChanged(List<BookModel> list)
        {
            _currentBookList = list;
        }

        public List<BookModel> SortBooks(SortingEnums.SortingMethod selectedMethod, SortingEnums.BookQuantity selectedQuantity,
            SortingEnums.Genre selectedCategory, SortingEnums.AlphabeticalSorting selectedAlphabetical)
        {
            List<BookModel> bookList = new List<BookModel>();
            List<AuthorModel> authorList = new List<AuthorModel>();

            authorList = _authBaseRepository.GetAll().ToList();

            if (selectedCategory == SortingEnums.Genre.NOT_SET)
            {
                // If no category is selected, takes the default bookList which is defined above.
                if (_currentBookList != null && _currentBookList.Count != 0) bookList = _currentBookList;
                else bookList = _bookBaseRepository.GetAll().ToList();
            }
            else
            {
                // If a category is selected, only take books with that category.
                if (_currentBookList != null && _currentBookList.Count != 0) bookList = _currentBookList;
                else bookList = _bookBaseRepository.GetAll().Where(c => c.Category == string.Join(" ", selectedCategory.ToString().Split('_'))).ToList();

            }

            if (selectedQuantity == SortingEnums.BookQuantity.NOT_SET)
            {
                selectedQuantity = (SortingEnums.BookQuantity)999;
            }

            // app startup setup
            if (selectedMethod == SortingEnums.SortingMethod.NOT_SET && selectedQuantity == SortingEnums.BookQuantity.NOT_SET)
            {
                bookList = bookList.Take(bookList.Count).ToList();
            }

            // combobox
            else if (selectedMethod == SortingEnums.SortingMethod.NOT_SET)
            {
                bookList = bookList.Take((int)selectedQuantity).ToList();
            }
            else if (selectedMethod == SortingEnums.SortingMethod.Downloads)
            {
                bookList = bookList.OrderByDescending(d => d.Downloads).Take((int)selectedQuantity).ToList();
            }
            else if (selectedMethod == SortingEnums.SortingMethod.Copies)
            {
                bookList = bookList.OrderByDescending(b => b.Copies).Take((int)selectedQuantity).ToList();
            }
            else if (selectedAlphabetical == SortingEnums.AlphabeticalSorting.Authors)
            {
                bookList = bookList.OrderByDescending(b => b.Author.LastName != " ")
                   .ThenBy(b => b.Author.LastName)
                   .ThenBy(b => b.Author.FirstName)
                   .Union(bookList.Where(b => b.Author.LastName == " "))
                   .Take((int)selectedQuantity)
                   .ToList();
            }
            else if (selectedAlphabetical == SortingEnums.AlphabeticalSorting.Books)
            {
                bookList = bookList.OrderBy(b => b.Title).Take((int)selectedQuantity).ToList();
            }

            _booksStore.CurrentBookList = bookList;
            return bookList;
        }
    }
}
