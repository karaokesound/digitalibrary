using Library.UI.Model;
using Library.UI.ViewModel;

namespace Library.UI.Service
{
    public interface IValidationService
    {
        //amend test delete later//
        public bool SignUpValidation(UserModel user);

        public bool SignInValidation(UserModel databaseUserModel, UserModel user);

        public bool LoginErrorInfoValidation(string username);

        public bool PasswordErrorInfoValidation(string password);

        public bool EmailValidation(string email);

        public bool OtherErrorInfoValidation(string userData);
    }
}
