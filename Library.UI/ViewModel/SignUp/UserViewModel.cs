using Library.UI.Services;
using System;

namespace Library.UI.ViewModel
{
    public class UserViewModel : ValidationBaseViewModel
    {
        private Guid _userId;
        public Guid UserId
        {
            get => _userId;
            set
            {
                _userId = value;
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
                OnPropertyChanged();
                bool validation = ValidationService.LoginErrorInfoValidation(_username);

                if (string.IsNullOrEmpty(_username))
                {
                    ClearErrors();
                    return;
                }

                if (string.IsNullOrWhiteSpace(Username))
                {
                    AddError("Enter your username");
                }
                else if (validation == false)
                {
                    AddError("Incorrect username. Check requirements");
                }
                else ClearErrors();
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
                bool validation = ValidationService.PasswordErrorInfoValidation(_password);

                if (string.IsNullOrEmpty(Password))
                {
                    ClearErrors();
                    return;
                }

                if (string.IsNullOrWhiteSpace(Password))
                {
                    AddError("Enter your password");
                }
                else if (Password.Length < 5 || validation == false)
                {
                    AddError("Incorrect password. Check requirements");
                }
                else ClearErrors();
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
                bool validation = ValidationService.OtherErrorInfoValidation(_firstName);

                if (string.IsNullOrEmpty(_firstName))
                {
                    ClearErrors();
                    return;
                }

                if (string.IsNullOrWhiteSpace(_firstName))
                {
                    AddError("Enter your first name");
                }
                else if (validation == false)
                {
                    AddError("Incorrect first name. Check requirements");
                }
                else ClearErrors();
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
                bool validation = ValidationService.OtherErrorInfoValidation(_lastName);

                if (string.IsNullOrEmpty(_lastName))
                {
                    ClearErrors();
                    return;
                }

                if (string.IsNullOrWhiteSpace(_lastName))
                {
                    AddError("Enter your last name");
                }
                else if (validation == false)
                {
                    AddError("Incorrect last name. Check requirements");
                }
                else ClearErrors();
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
                bool validation = ValidationService.EmailValidation(_email);

                if (string.IsNullOrEmpty(_email))
                {
                    ClearErrors();
                    return;
                }

                if (string.IsNullOrWhiteSpace(_email) || validation == false)
                {
                    AddError("Incorrect email. Check requirements");
                }
                else ClearErrors();
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

                bool validation = ValidationService.OtherErrorInfoValidation(_city);

                if (string.IsNullOrEmpty(_city))
                {
                    ClearErrors();
                    return;
                }

                if (string.IsNullOrWhiteSpace(_city))
                {
                    AddError("Enter your city");
                }
                else if (validation == false)
                {
                    AddError("Incorrect city name. Check requirements");
                }
                else ClearErrors();
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
