using Library.UI.Model;
using System;

namespace Library.UI.Services
{
    public interface IUserAuthenticationService
    {
        public bool IsUserAuthenticated { get; }

        public AccountModel LoggedUser { get; }

        public Guid UserId { get; }

        public void Authentication(string loggingUsername, string dbUsername, string loggingPassword,
            string dbPassword, AccountModel dbUser);
    }
}
