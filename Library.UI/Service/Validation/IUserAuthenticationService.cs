using Library.UI.Model;
using System;
using System.Collections.Generic;

namespace Library.UI.Services
{
    public interface IUserAuthenticationService
    {
        public Guid UserId { get; }
        
        public AccountModel LoggedUser { get; }

        public bool IsUserAuthenticated { get; }

        public List<BookModel> _requestedBooks { get; }

        public void Authentication(string loggingUsername, string dbUsername, string loggingPassword,
            string dbPassword, AccountModel dbUser, List<BookModel> requestedBooks);
    }
}
