using Library.UI.Model;
using Library.UI.Service;
using Library.UI.ViewModel;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Library.UI.Services
{
    public class ValidationService : ValidationBaseViewModel, IValidationService
    {
        public Regex usernameValidationRegex = new Regex(@"^[a-zA-Z0-9][a-zA-Z0-9]{1,8}[a-zA-Z0-9]$");
        public Regex firstLastNameCityValidationRegex = new Regex(@"^[a-zA-Z]{1}[a-zA-Z]{0,23}[a-zA-Z]{1}$");
        public Regex passwordValidationRegex = new Regex(@"^(?=.*\d)(?=.*\W)(?!.*\s)(?!.*\s$).{6,15}$");
        public Regex emailValidationRegex = new Regex("^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*\\.[a-zA-Z]{2,}$");

        public bool SignUpValidation(AccountModel user)
        {
            if (string.IsNullOrEmpty(user.Username)
                || !usernameValidationRegex.IsMatch(user.Username)
                || user.Username.Length < 3)
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Sign Up");
                return false;
            }
            else if (string.IsNullOrEmpty(user.Password)
                || !passwordValidationRegex.IsMatch(user.Password))
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Sign Up");
                return false;
            }
            else if (string.IsNullOrEmpty(user.FirstName)
                || !firstLastNameCityValidationRegex.IsMatch(user.FirstName))
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Sign Up");
                return false;
            }
            else if (string.IsNullOrEmpty(user.LastName)
                || !firstLastNameCityValidationRegex.IsMatch(user.LastName))
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Sign Up");
                return false;
            }
            else if (string.IsNullOrEmpty(user.Email)
                || !emailValidationRegex.IsMatch(user.Email))
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Sign Up");
                return false;
            }
            else if (string.IsNullOrEmpty(user.City)
                || !firstLastNameCityValidationRegex.IsMatch(user.City))
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Sign Up");
                return false;
            }
            else if (user.Library == null)
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Sign Up");
                return false;
            }
            return true;
        }

        public bool SignInValidation(AccountModel dbUser, AccountModel loggingUser)
        {
            bool isValid = true;

            
            if (string.IsNullOrEmpty(loggingUser.Username) || string.IsNullOrEmpty(loggingUser.Password))
            {
                MessageBox.Show("Enter your username and password", "Login");
                isValid = false;
            }
            else if (loggingUser.AccountId == Guid.Empty && dbUser == null)
            {
                MessageBox.Show("There is no user with this username. Try again", "Login");
                isValid = false;
            }
            else if (loggingUser == null)
            {
                MessageBox.Show("Enter your username and password", "Login");
                isValid = false;
            }
            else if (dbUser != null)
            {
                if (dbUser.Username == loggingUser.Username && dbUser.Password == loggingUser.Password)
                {
                    isValid = true;
                }
                else MessageBox.Show("Incorrect password. Forgot password?", "Login");
            }

            return isValid;
        }

        public bool LoginErrorInfoValidation(string username)
        {
            return usernameValidationRegex.IsMatch(username);
        }

        public bool PasswordErrorInfoValidation(string password)
        {
            return passwordValidationRegex.IsMatch(password);
        }

        public bool EmailValidation(string email)
        {
            return emailValidationRegex.IsMatch(email);
        }

        public bool OtherErrorInfoValidation(string userData)
        {
            return firstLastNameCityValidationRegex.IsMatch(userData);
        }
    }
}
