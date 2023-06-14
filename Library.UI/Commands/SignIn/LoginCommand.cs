using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Services;
using Library.UI.ViewModel;
using System.Linq;

namespace Library.UI.Commands.SignIn
{
    public class LoginCommand : CommandBase
    {
        private readonly SignInPanelViewModel _signInPanelVM;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IMappingService _mappingService;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

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

            var requestedBooks = _bookBaseRepository.GetAll().Where(b => b.AnyRequest == true && b.RequestUserId == dbUser.AccountId).ToList();

            _userAuthenticationService.Authentication(loggingUser.Username, dbUser.Username, loggingUser.Password,
                dbUser.Password, dbUser, requestedBooks);
            _signInPanelVM.RaiseUserAuthEvent();
        }

        public LoginCommand(SignInPanelViewModel signInPanelVM, IUserAuthenticationService userAuthenticationService,
            IValidationService validationService, IUserRepository userRepository, IMappingService mappingService, 
            IBaseRepository<BookModel> bookBaseRepository)
        {
            _signInPanelVM = signInPanelVM;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _mappingService = mappingService;
            _bookBaseRepository = bookBaseRepository;
        }
    }
}
