using Library.UI.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Documents;

namespace Library.UI.Services
{
    public class UserStoreService
    {
        private UserModel _user = null;

        public UserStoreService()
        {
        }

        private static UserStoreService _instance;
        public static UserStoreService Instance()
        {
            if (_instance == null)
            {
                _instance = new UserStoreService();
            }
            return _instance;
        }

        public static void AddUser(UserModel newUser)
        {
            Instance()._user = newUser;
        }

        public static UserModel ReturnUser()
        {
            return Instance()._user;
        }
    }
}
