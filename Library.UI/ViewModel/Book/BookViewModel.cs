using Library.UI.Model;
using System;

namespace Library.UI.ViewModel
{
    public class BookViewModel : ValidationBaseViewModel
    {
        public Guid _id;

        public Guid Id 
        {
            get => _id;
            set
            {
                _id = value;
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

        public Author _author;

        public Author Author 
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        public int? _volume;

        public int? Volume 
        {
            get => _volume;
            set
            {
                _volume = value;
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
