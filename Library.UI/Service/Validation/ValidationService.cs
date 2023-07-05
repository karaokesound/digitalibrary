using Library.UI.Model;
using Library.UI.Service;
using Library.UI.ViewModel;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Library.UI.Services
{
    public class ValidationService : ValidationBaseViewModel, IValidationService
    {
        public string Notification { get; set; }

        public Regex usernameValidationRegex = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])[a-zA-Z\d]{3,15}$");
        public Regex firstLastNameCityValidationRegex = new Regex(@"^[a-zA-Z]{1}[a-zA-Z]{0,23}[a-zA-Z]{1}$");
        public Regex passwordValidationRegex = new Regex(@"^(?=.*\d)(?=.*\W)(?!.*\s)(?!.*\s$).{6,15}$");
        public Regex emailValidationRegex = new Regex("^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*\\.[a-zA-Z]{2,}$");

        public bool SignUpValidation(AccountModel user)
        {
            if (string.IsNullOrEmpty(user.Username)
                || !usernameValidationRegex.IsMatch(user.Username))
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

        public string UsernameErrorInfoValidation(string username)
        {
            Regex unvalidSigns = new Regex(@"[!@#$%^&*(),.?""':{}|<>\[\]\s]");

            if (username.Count() < 3)
            {
                Notification = "Username minimum 3 characters";
            }
            else if (username.Count() > 15)
            {
                Notification = "Username maximum 15 characters";
            }
            else if (username.Count() >= 3 && usernameValidationRegex.IsMatch(username) == false && unvalidSigns.IsMatch(username) == false)
            {
                Notification = "Minimum 1 digit";
            }
            else if (unvalidSigns.IsMatch(username) == true)
            {
                Notification = "Username must contain only letters and digits";
            }
            else Notification = "";

            return Notification;
        }

        public string PasswordErrorInfoValidation(string password)
        {
            string digitsPattern = @"[!@#$%^&*(),.?""':{}|<>\[\]\s]";
            string specialCharsPattern = @"[^\w\s]";

            if (password.Count() < 6)
            {
                Notification = "Password minimum 6 characters";
            }
            else if (password.Count() < 6 && !Regex.IsMatch(password, digitsPattern))
            {
                Notification = "Password must contain at least one digit";
            }
            else if (password.Count() < 6 && !Regex.IsMatch(password, specialCharsPattern))
            {
                Notification = "Password must contain at least one special mark";
            }
            else Notification = "";

            return Notification;
        }

        public string EmailValidation(string email)
        {
            if (!emailValidationRegex.IsMatch(email))
            {
                Notification = "This email doesn't exist. Check it and try again";
            }
            else Notification = "";

            return Notification;
        }

        public string OtherErrorInfoValidation(string userInput)
        {
            if (userInput.Count() < 2)
            {
                Notification = "You have to insert minimum 2 characters";
            }
            else if (userInput.Count() > 25)
            {
                Notification = "You can insert maximum 25 characters";
            }
            else if (userInput.Count() > 2 && userInput.Count() < 25 && !firstLastNameCityValidationRegex.IsMatch(userInput))
            {
                Notification = "You can insert only letters";
            }
            else Notification = "";

            return Notification;
        }
    }
}
