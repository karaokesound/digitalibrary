using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service.Data;
using Library.UI.Service;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.Service.SignIn;

namespace Library.UI.Commands.Profile
{
    public class ProfileUpdateViewCommand : CommandBase
    {
        private readonly ProfilePanelViewModel _accountPanelVM;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataFiltering;

        private readonly ILoggedAccount _loggedAccount;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly SignInPanelViewModel _signInPanelViewModel;

        public ProfileUpdateViewCommand(ProfilePanelViewModel accountPanelVM, IBaseRepository<BookModel> bookBaseRepository, 
            IMappingService mappingService, IDataSorting dataFiltering, ILoggedAccount loggedAccount, IUserAuthenticationService userAuthenticationService, 
            IValidationService validationService, IUserRepository userRepository, SignInPanelViewModel signInPanelViewModel)
        {
            _accountPanelVM = accountPanelVM;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataFiltering = dataFiltering;
            _loggedAccount = loggedAccount;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _signInPanelViewModel = signInPanelViewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Library")
            {
                _accountPanelVM.SelectedViewModel = new LibraryViewModel(_bookBaseRepository, _mappingService, _dataFiltering, _loggedAccount, 
                    _userAuthenticationService, _validationService, _userRepository, _signInPanelViewModel);
            }
        }
    }
}
