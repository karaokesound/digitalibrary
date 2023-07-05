using Library.UI.Model;

namespace Library.UI.Service
{
    public interface IValidationService
    {
        string Notification { get; set; }

        public bool SignUpValidation(AccountModel user);

        public bool SignInValidation(AccountModel databaseUserModel, AccountModel user);

        public string UsernameErrorInfoValidation(string username);

        public string PasswordErrorInfoValidation(string password);

        public string EmailValidation(string email);

        public string OtherErrorInfoValidation(string userData);
    }
}
