using Library.UI.Model;
using System;
using System.Collections.Generic;

namespace Library.UI.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public Guid UserId { get; private set; }

        public AccountModel LoggedUser { get; private set; }

        public bool IsUserAuthenticated { get; private set; }

        public List<BookModel> _requestedBooks { get; private set; }

        public void Authentication(string loggingUsername, string dbUsername, string loggingPassword,
            string dbPassword, AccountModel dbUser, List<BookModel> requestedBooks)
        {
            if (requestedBooks == null) requestedBooks = null;

            if (loggingUsername == dbUsername && loggingPassword == dbPassword)
            {
                UserId = dbUser.AccountId;
                LoggedUser = dbUser;
                IsUserAuthenticated = true;
                _requestedBooks = requestedBooks;
            }
            else IsUserAuthenticated = false;
        }

        public UserAuthenticationService()
        {
            _requestedBooks = new List<BookModel>();
        }
    }
}
