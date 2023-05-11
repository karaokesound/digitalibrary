using Library.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Services
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserModel GetUserByUsername(string username)
        {
            var dbUser = _dbSet.FirstOrDefault(dbU => dbU.Username == username);
            return dbUser;
        }
    }
}
