using Library.UI.Model;
using System;
using static Library.UI.Model.BookModel;

namespace Library.UI.ViewModel
{
    public class BookViewModel : ValidationBaseViewModel
    {
        public Guid _bookId;
        public Guid BookId 
        {
            get => _bookId;
            set
            {
                _bookId = value;
                OnPropertyChanged();
            }
        }

        public string _title;
        public string Title 
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();

                if (string.IsNullOrEmpty(Title))
                {
                    AddError("Add a title"); //CallerMemberName takes the property[Title] by himself
                }
                else ClearErrors();
            }
        }

        public AuthorModel _author;
        public AuthorModel Author 
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        public Genre? _category;
        public Genre? Category 
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        public int _pages;
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
