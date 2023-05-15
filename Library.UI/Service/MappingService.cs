using Library.UI.Model;
using Library.UI.Service;
using Library.UI.ViewModel;

namespace Library.UI.Services
{
    public class MappingService : IMappingService
    {
        // USER MAPPING SERVICE //
        public UserViewModel UserModelToViewModel(UserModel signUp)
        {
            return new UserViewModel(_validationService)
            {
                UserId = signUp.UserId,
                Username = signUp.Username,
                Password = signUp.Password,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                City = signUp.City,
                Library = signUp.Library,
            };
        }

        public UserModel UserViewModelToModel(UserViewModel signUpVM)
        {
            return new UserModel()
            {
                UserId = signUpVM.UserId,
                Username = signUpVM.Username,
                Password = signUpVM.Password,
                FirstName = signUpVM.FirstName,
                LastName = signUpVM.LastName,
                Email = signUpVM.Email,
                City = signUpVM.City,
                Library = signUpVM.Library,
            };
        }

        private readonly IValidationService _validationService;

        public MappingService(IValidationService validationService)
        {
            _validationService = validationService;
        }
    }
}
