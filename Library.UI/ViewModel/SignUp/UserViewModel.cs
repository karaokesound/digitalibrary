using Library.UI.Services;
using System;
using System.Windows.Controls;

namespace Library.UI.ViewModel
{
    public class UserViewModel : ValidationBaseViewModel
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                if (Username.Length < 5 && string.IsNullOrEmpty(Username) && string.IsNullOrWhiteSpace(Username))
                {
                    AddError("Enter your nickname");
                }
                else ClearErrors();

                OnPropertyChanged();
            }
        }

        public string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
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

        private string _email;
        public string Email 
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _city;
        public string City 
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }

        private string _library;
        public string Library
        {
            get => _library;
            set
            {
                _library = value;
                OnPropertyChanged();
            }
        }
    }
}
