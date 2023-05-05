using Library.UI.Model;
using Library.UI.ViewModel;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Library.UI.Services
{
    public class ValidationService
    {
        public static bool SignUpValidation(UserModel user)
        {
            Regex usernameValidationRegex = new Regex(@"^[a-zA-Z0-9][a-zA-Z0-9]{1,8}[a-zA-Z0-9]$");
            Regex firstLastNameCityValidationRegex = new Regex(@"^[a-zA-Z]{1}[a-zA-Z]{0,23}[a-zA-Z]{1}$");
            Regex passwordValidationRegex = new Regex(@"^(?=.*\d)(?=.*\W)(?!.*\s)(?!.*\s$).{6,15}$");
            Regex emailValidationRegex = new Regex("^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*\\.[a-zA-Z]{2,}$");


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
                || !emailValidationRegex.IsMatch(user.Username))
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

        public static bool SignInValidation(UserModel databaseUserModel, UserViewModel user)
        {
            UserViewModel? databaseUser = null;

            bool isValid = true;

            if (user == null)
            {
                MessageBox.Show("Enter your username and password", "Login");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                MessageBox.Show("Enter your username and password", "Login");
                isValid = false;
            }
            else if (user.Id == Guid.Empty && databaseUserModel == null)
            {
                MessageBox.Show("Incorrect username or password. Forgot password?", "Login");
                isValid = false;
            }
            else if (databaseUserModel != null)
            {
                databaseUser = MappingService.UserModelToViewModel(databaseUserModel);
                if (databaseUser.Username == user.Username && databaseUser.Password == user.Password)
                {
                    isValid = true;
                }
                else MessageBox.Show("Incorrect username or password. Forgot password?", "Login");
            }

            return isValid;
        }

        public static bool LoginErrorInfoValidation(string username)
        {
            Regex usernameValidationRegex = new Regex(@"^[a-zA-Z0-9][a-zA-Z0-9]{1,8}[a-zA-Z0-9]$");
            return usernameValidationRegex.IsMatch(username);
        }

        public static bool PasswordErrorInfoValidation(string password)
        {
            Regex passwordValidationRegex = new Regex(@"^(?=.*\d)(?=.*\W)(?!.*\s)(?!.*\s$).{6,15}$");
            return passwordValidationRegex.IsMatch(password);
        }

        public static bool EmailValidation(string email)
        {
            Regex emailValidationRegex = new Regex("^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*\\.[a-zA-Z]{2,}$");
            return emailValidationRegex.IsMatch(email);
        }

        public static bool OtherErrorInfoValidation(string userData)
        {
            Regex firstLastNameCityValidationRegex = new Regex(@"^[a-zA-Z]{1}[a-zA-Z]{0,23}[a-zA-Z]{1}$");
            return firstLastNameCityValidationRegex.IsMatch(userData);
        }
        //public static bool WhiteSpaceValidation(string userData)
        //{
        //    //bool isValid = true;
        //    //for (int i = 0; i < userData.Length; i++)
        //    //{
        //    //    if (userData[i] == ' ')
        //    //    {
        //    //        isValid = false;
        //    //    }
        //    //}
        //    //return isValid;
        //}

        //public static bool AtTheStartWhiteSpaceValidation(string userData)
        //{
        //    //bool isValid = true;
        //    //for (int i = 0; i < userData.Length; i++)
        //    //{
        //    //    if (userData[i] == ' ')
        //    //    {
        //    //        isValid = false;
        //    //    }
        //    //    else break;
        //    //}
        //    //return isValid;
        //}

        
    }
}
