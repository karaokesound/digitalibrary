using Library.UI.Model;
using Library.UI.ViewModel;

namespace Library.UI.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public bool Authentication(string username, string password)
        {
            UserModel user = UserStoreService.ReturnUser();
            UserViewModel userVM = MappingService.UserModelToViewModel(user);

            if (userVM.Username == username && userVM.Password == password)
            {
                return true;
            }
            else return false;
        }
    }
}
