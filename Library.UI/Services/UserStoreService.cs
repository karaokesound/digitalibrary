using Library.UI.Model;

namespace Library.UI.Services
{
    public class UserStoreService
    {
        private static UserStoreService _instance;

        private static UserModel _user;

        public UserStoreService()
        {
        }

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
            _user = newUser;
        }

        public static UserModel ReturnUser()
        {
            return _user;
        }
    }
}
