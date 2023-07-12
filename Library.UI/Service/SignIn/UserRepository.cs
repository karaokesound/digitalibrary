using Library.UI.Model;
using System.Linq;

namespace Library.UI.Services
{
    public class UserRepository : BaseRepository<AccountModel>, IUserRepository
    {
        public AccountModel GetUserByUsername(string username)
        {
            var dbUser = _dbSet.FirstOrDefault(dbU => dbU.Username == username);
            return dbUser;
        }
    }
}
