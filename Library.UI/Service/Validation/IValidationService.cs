using Library.UI.Model;

namespace Library.UI.Service
{
    public interface IValidationService
    {
        //amend test delete later//
        public bool SignUpValidation(AccountModel user);

        public bool SignInValidation(AccountModel databaseUserModel, AccountModel user);

        public bool LoginErrorInfoValidation(string username);

        public bool PasswordErrorInfoValidation(string password);

        public bool EmailValidation(string email);

        public bool OtherErrorInfoValidation(string userData);
    }
}
