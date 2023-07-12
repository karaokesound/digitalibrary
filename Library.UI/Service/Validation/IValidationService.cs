using Library.UI.Model;

namespace Library.UI.Service
{
    public interface IValidationService
    {
        public bool SignUpValidation(AccountModel user);

        public bool SignInValidation(AccountModel databaseUserModel, AccountModel user);
    }
}
