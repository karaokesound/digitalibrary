using Library.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Services
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel GetUserByUsername(string username);
    }
}
