using Library.UI.Model;
using System.Collections.Generic;
using System;
using static Library.UI.Model.BookModel;

namespace Library.UI.ViewModel.Library
{
    public class BookViewModel : BaseViewModel
    {
        private Guid _bookId;
        public Guid BookId 
        {
            get => _bookId;
            set
            {
                _bookId = value;
                OnPropertyChanged();
            }
        }

        private string _title;
        public string Title 
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private ICollection<AuthorModel> _authors;
        public ICollection<AuthorModel> Authors 
        {
            get => _authors;
            set
            {
                _authors = value;
                OnPropertyChanged();
            }
        }

        private Genre _category;
        public Genre Category 
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        private int _pages;
        public int Pages 
        {
            get => _pages;
            set
            {
                _pages = value;
                OnPropertyChanged();
            }
        }
    }
}
