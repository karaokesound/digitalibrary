using Library.UI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Library.UI.Services
{
    public class UserStoreService
    {
        private static UserStoreService _instance;

        private static UserModel _user;

        public UserStoreService()
        {
        }

        public static UserStoreService Instance()
        {
            if (_instance == null)
            {
                _instance = new UserStoreService();
            }
            return _instance;
        }

        public static void AddUser(UserModel newUser)
        {
            _user = newUser;
        }

        public static UserModel ReturnUser()
        {
            return _user;
        }

        // validation
        public static Regex _usernameValidationRegex = new Regex("^[a-zA-Z0-9]+$");

        public static Regex _firstLastNameCityValidationRegex = new Regex("^[a-zA-Z]+$");

        public static bool AreUserDataValid(UserModel username)
        {
            if (string.IsNullOrEmpty(username.Username)
                || !_usernameValidationRegex.IsMatch(username.Username)
                || username.Username.Length < 5)
            {
                MessageBox.Show("Username must contain only characters, digits and be at leat 5 characters long", "Invalid Username");
                return false;
            }
            else if (string.IsNullOrEmpty(username.FirstName)
                || !_firstLastNameCityValidationRegex.IsMatch(username.FirstName))
            {
                MessageBox.Show("First name must contain only characters", "Invalid First Name");
                return false;
            }
            else if (string.IsNullOrEmpty(username.LastName)
                || !_firstLastNameCityValidationRegex.IsMatch(username.LastName))
            {
                MessageBox.Show("Last name must contain only characters", "Invalid Last Name");
                return false;
            }
            else if (string.IsNullOrEmpty(username.City)
                || !_firstLastNameCityValidationRegex.IsMatch(username.City))
            {
                MessageBox.Show("City name must contain only characters", "Invalid City Name");
                return false;
            }
            return true;
        }

    }
}
