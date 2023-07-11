using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System;
using System.Collections.Generic;

namespace Library.UI.Stores
{
    public class BookStore
    {
        public event Action<List<BookModel>> BookListChanged;

        public List<BookModel> CurrentBookList { get; set; }

        public List<BookModel> FilteredBookList { get; set; }

        private readonly SignInPanelViewModel _signInPanelVM;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        public void OnBookListChanged()
        {
            if (FilteredBookList.Count != 0)
            {
                BookListChanged?.Invoke(FilteredBookList);
            }
            else BookListChanged?.Invoke(CurrentBookList);
        }

        public void OnStartupBookListChanged()
        {
            if (FilteredBookList.Count != 0)
            {
                BookListChanged?.Invoke(CurrentBookList);
            }
            else return;
        }

        public BookStore(SignInPanelViewModel signInPanelVM, IBaseRepository<BookModel> bookBaseRepository)
        {
            CurrentBookList = new List<BookModel>();
            FilteredBookList = new List<BookModel>();
            _bookBaseRepository = bookBaseRepository;
        }
    }
}
