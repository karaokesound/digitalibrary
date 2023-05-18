using Library.UI.Model;
using System.Collections.Generic;
using System;
using static Library.UI.Model.BookModel;
using Library.Models.Model;

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

        private AuthorModel _author;
        public AuthorModel Author 
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        private string _category;
        public string Category 
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        private ICollection<LanguageModel> _languages;
        public ICollection<LanguageModel> Languages 
        {
            get => _languages;
            set
            {
                _languages = value;
                OnPropertyChanged();
            }
        }
    }
}
