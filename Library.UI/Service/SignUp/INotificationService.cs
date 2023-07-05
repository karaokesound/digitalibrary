namespace Library.UI.Service.SignUp
{
    public interface INotificationService
    {
        string Notification { get; set; }
        string UsernameErrorNotification(string username);

        string PasswordErrorNotification(string password);

        string EmailErrorNotification(string email);

        string OtherErrorNotification(string userData);
    }
}
