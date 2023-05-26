using Library.UI.Model;
using System.Collections.Generic;
using System;

namespace Library.UI.ViewModel.Library
{
    public class AuthorViewModel : BaseViewModel
    {
        private Guid _authorId;
        public Guid AuthorId 
        { 
            get => _authorId;
            set
            {
                _authorId = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;
        public string FirstName 
        { 
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName 
        { 
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private int? _birthYear;
        public int? BirthYear 
        { 
            get => _birthYear;
            set
            {
                _birthYear = value;
                OnPropertyChanged();
            }
        }

        private int? _deathYear;
        public int? DeathYear 
        { 
            get => _deathYear;
            set
            {
                _deathYear = value;
                OnPropertyChanged();
            }
        }

        private ICollection<BookModel> _books;
        public ICollection<BookModel> Books 
        { 
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }
    }
}
