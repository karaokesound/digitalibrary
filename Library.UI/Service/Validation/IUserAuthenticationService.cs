using Library.UI.Model;
using System;
using System.Collections.Generic;

namespace Library.UI.Services
{
    public interface IUserAuthenticationService
    {
        Guid UserId { get; }
        
        AccountModel LoggedUser { get; }

        bool IsUserAuthenticated { get; }

        List<BookModel> _requestedBooks { get; }

        void Authentication(string loggingUsername, string dbUsername, string loggingPassword,
            string dbPassword, AccountModel dbUser, List<BookModel> requestedBooks);

        void UserLogout(bool isLogout);
    }
}
