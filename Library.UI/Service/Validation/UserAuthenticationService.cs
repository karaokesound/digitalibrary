namespace Library.UI.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; }
        public void Authentication(string loggingUsername, string databaseUsername, string loggingPassword,
            string databasePassword)
        {
            if (loggingUsername == databaseUsername && loggingPassword == databasePassword)
            {
                IsUserAuthenticated = true;
            }
            else IsUserAuthenticated = false;
        }
    }
}
