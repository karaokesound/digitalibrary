using System.Linq;
using System.Text.RegularExpressions;

namespace Library.UI.Service.SignUp
{
    public class NotificationService : INotificationService
    {
        public string Notification { get; set; }

        public string digitsSpecialCharsPattern = @"^(?=.*[\s\d\p{P}])|.*[\.]$";

        public string specialCharsPattern = @"[\p{P}\p{S}\s]";

        public Regex usernameValidationRegex = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])[a-zA-Z\d]{3,15}$");

        public Regex firstLastNameCityValidationRegex = new Regex(@"^[a-zA-Z]{1}[a-zA-Z]*[a-zA-Z]{1}$");

        public Regex passwordValidationRegex = new Regex(@"^(?=.*\d)(?=.*\W)(?!.*\s)(?!.*\s$).{6,15}$");

        public Regex emailValidationRegex = new Regex("^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*\\.[a-zA-Z]{2,}$");

        public string UsernameErrorNotification(string username)
        {
            if (Regex.IsMatch(username, specialCharsPattern))
            {
                Notification = "Username can contain only letters and digits";
            }
            else if (username.Count() < 3)
            {
                Notification = "Username minimum 3 characters";
            }
            else if (username.Count() > 15)
            {
                Notification = "Username maximum 15 characters";
            }
            else Notification = "";

            return Notification;
        }

        public string PasswordErrorNotification(string password)
        {
            string specialCharsPattern = @"[!@#$%^&*(),.?""':{}|<>\[\]\s]";
            string digitsPattern = @"[^\w\s]";
            string lettersPattern = @"[a-zA-Z]";
            string spacesPattern = @"\s+";

            if (Regex.IsMatch(password, spacesPattern))
            {
                Notification = "Wrong password";
            }
            else if (!Regex.IsMatch(password, specialCharsPattern))
            {
                Notification = "Password must contain at least one digit";
            }
            else if (!Regex.IsMatch(password, digitsPattern))
            {
                Notification = "Password must contain at least one special mark";
            }
            else if (!Regex.IsMatch(password, lettersPattern))
            {
                Notification = "Password must contain at least one letter";
            }
            else if (password.Count() < 6)
            {
                Notification = "Password minimum 6 characters";
            }
            else if (password.Count() > 25)
            {
                Notification = "Password maximum 25 characters";
            }
            else Notification = "";

            return Notification;
        }

        public string EmailErrorNotification(string email)
        {
            if (!emailValidationRegex.IsMatch(email))
            {
                Notification = "This email doesn't exist. Check it and try again";
            }
            else Notification = "";

            return Notification;
        }

        public string OtherErrorNotification(string userInput)
        {
            if (Regex.IsMatch(userInput, digitsSpecialCharsPattern))
            {
                Notification = "You can insert only letters";
            }
            else if (userInput.Count() < 2)
            {
                Notification = "You have to insert minimum 2 characters";
            }
            else if (userInput.Count() > 25)
            {
                Notification = "You can insert maximum 25 characters";
            }
            else Notification = "";

            return Notification;
        }
    }
}
