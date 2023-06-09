using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.SignIn;
using Library.UI.Services;
using Library.UI.ViewModel;

namespace Library.UI.Commands.SignIn
{
    public class LoginCommand : CommandBase
    {
        private readonly SignInPanelViewModel _signInPanelVM;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IMappingService _mappingService;

        private readonly ILoggedAccount _loggedAccount;

        public override void Execute(object parameter)
        {
            AccountViewModel loggingUserVM = _signInPanelVM.LoggingUsernamePassword;

            AccountModel loggingUser = _mappingService.UserViewModelToModel(loggingUserVM);
            AccountModel dbUser = _userRepository.GetUserByUsername(loggingUser.Username);
            bool validation = _validationService.SignInValidation(dbUser, loggingUser);
            if (validation == false)
            {
                return;
            }

            _userAuthenticationService.Authentication(loggingUser.Username, dbUser.Username, loggingUser.Password,
                dbUser.Password);
            _signInPanelVM.RaiseUserAuthEvent();

            _loggedAccount.TakeAccountId(dbUser.AccountId);
            _signInPanelVM.RaiseInterceptLoggedUserIdEvent();
        }

        public LoginCommand(SignInPanelViewModel signInPanelVM, IUserAuthenticationService userAuthenticationService,
            IValidationService validationService, IUserRepository userRepository, IMappingService mappingService, 
            ILoggedAccount loggedAccount)
        {
            _signInPanelVM = signInPanelVM;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _mappingService = mappingService;
            _loggedAccount = loggedAccount;
        }
    }
}
