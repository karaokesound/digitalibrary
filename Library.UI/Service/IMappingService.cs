using Library.UI.Model;
using Library.UI.ViewModel;

namespace Library.UI.Service
{
    public interface IMappingService
    {
        public UserViewModel UserModelToViewModel(UserModel signUp);

        public UserModel UserViewModelToModel(UserViewModel signUpVM);
    }
}
