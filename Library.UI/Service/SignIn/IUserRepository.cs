using Library.UI.Model;

namespace Library.UI.Services
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel GetUserByUsername(string username);
    }
}
