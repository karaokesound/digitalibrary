using System;

namespace Library.UI.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; }

        public Guid UserId { get; private set; }

        public void Authentication(string loggingUsername, string dbUsername, string loggingPassword,
            string dbPassword, Guid dbId)
        {
            if (loggingUsername == dbUsername && loggingPassword == dbPassword)
            {
                IsUserAuthenticated = true;
                UserId = dbId;
            }
            else IsUserAuthenticated = false;
        }
    }
}
