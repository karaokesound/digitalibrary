using Library.UI.Model;
using System.Text.RegularExpressions;
using System.Windows;

namespace Library.UI.Services
{
    public class ValidationService
    {
        public static bool SignUpValidation(UserModel user)
        {
            Regex _usernameValidationRegex = new Regex("^[a-zA-Z0-9]+$");
            Regex _firstLastNameCityValidationRegex = new Regex("^[a-zA-Z]+$");

            if (string.IsNullOrEmpty(user.Username)
                || !_usernameValidationRegex.IsMatch(user.Username)
                || user.Username.Length < 3)
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Library Sign Up");
                return false;
            }
            else if (string.IsNullOrEmpty(user.FirstName)
                || !_firstLastNameCityValidationRegex.IsMatch(user.FirstName))
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Library Sign Up");
                return false;
            }
            else if (string.IsNullOrEmpty(user.LastName)
                || !_firstLastNameCityValidationRegex.IsMatch(user.LastName))
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Library Sign Up");
                return false;
            }
            else if (string.IsNullOrEmpty(user.City)
                || !_firstLastNameCityValidationRegex.IsMatch(user.City))
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Library Sign Up");
                return false;
            }
            else if (user.Library == null)
            {
                MessageBox.Show("Check that all fields are filled in correctly", "Library Sign Up");
                return false;
            }
            return true;
        }

        public static bool WhiteSpaceValidation(string userData)
        {
            bool isValid = true;
            for (int i = 0; i < userData.Length; i++)
            {
                if (userData[i] == ' ')
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public static bool AtTheStartWhiteSpaceValidation(string userData)
        {
            bool isValid = true;
            for (int i = 0; i < userData.Length; i++)
            {
                if (userData[i] == ' ')
                {
                    isValid = false;
                }
                else break;
            }
            return isValid;
        }

        public static bool EmailValidation(string email)
        {
            string pattern = "^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*\\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
