using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Services;
using Library.UI.ViewModel;
using System.Windows;

namespace Library.UI.Commands.SignIn
{
    public class LoginCommand : CommandBase
    {
        private readonly SignInPanelViewModel _signInPanelVM;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IMappingService _mappingService;

        public override void Execute(object parameter)
        {
            UserViewModel loggingUserVM = _signInPanelVM.LoggingUsernamePassword;

            UserModel loggingUser = _mappingService.UserViewModelToModel(loggingUserVM);
            UserModel dbUser = _userRepository.GetUserByUsername(loggingUser.Username) as UserModel;
            bool validation = _validationService.SignInValidation(dbUser, loggingUser);
            if (validation == false)
            {
                return;
            }

            _userAuthenticationService.Authentication(loggingUser.Username, dbUser.Username, loggingUser.Password,
                dbUser.Password);
            _signInPanelVM.RaiseUserAuthEvent();
        }

        public LoginCommand(SignInPanelViewModel signInPanelVM, IUserAuthenticationService
            userAuthenticationService, IValidationService validationService, IUserRepository userRepository, IMappingService mappingService)
        {
            _signInPanelVM = signInPanelVM;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _mappingService = mappingService;
        }
    }
}
