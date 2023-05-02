namespace Library.UI.Services
{
    public interface IUserAuthenticationService
    {
        public bool Authentication(string username, string password);
    }
}
