using Library.UI.Model;
using System.Collections;

namespace Library.UI.Services
{
    public interface IUserRepository
    {
        IEnumerable GetUsers();

        UserModel GetUserByID(int userId);

        void InsertUser(UserModel user);

        void DeleteUser(int userId);

        void UpdateUser(UserModel user);

        void Save();
    }
}
