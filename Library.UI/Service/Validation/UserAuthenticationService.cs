using Library.UI.Model;
using System;

namespace Library.UI.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; }

        public AccountModel LoggedUser { get; private set; }

        public Guid UserId { get; private set; }

        public void Authentication(string loggingUsername, string dbUsername, string loggingPassword,
            string dbPassword, AccountModel dbUser)
        {
            if (loggingUsername == dbUsername && loggingPassword == dbPassword)
            {
                IsUserAuthenticated = true;
                UserId = dbUser.AccountId;
                LoggedUser = dbUser;
            }
            else IsUserAuthenticated = false;
        }
    }
}
