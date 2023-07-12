using Library.UI.Model;

namespace Library.UI.Services
{
    public interface IUserRepository : IBaseRepository<AccountModel>
    {
        AccountModel GetUserByUsername(string username);
    }
}
