namespace Library.UI.Services
{
    public interface IUserAuthenticationService
    {
        public bool IsUserAuthenticated { get; }
        public void Authentication(string loggingUsername, string databaseUsername, string loggingPassword,
            string databasePassword);
    }
}
