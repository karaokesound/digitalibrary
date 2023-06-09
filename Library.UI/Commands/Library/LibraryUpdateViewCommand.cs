using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Service.SignIn;
using Library.UI.Services;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class LibraryUpdateViewCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryVM;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataSorting;

        private readonly ILoggedAccount _loggedAccount;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly SignInPanelViewModel _signInPanelViewModel;

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Profile")
            {
                _libraryVM.SelectedViewModel = new ProfilePanelViewModel(_bookBaseRepository, _mappingService, _dataSorting, _loggedAccount, 
                    _userAuthenticationService, _validationService, _userRepository, _signInPanelViewModel);
            }
        }

        public LibraryUpdateViewCommand(LibraryViewModel libraryVM, IBaseRepository<BookModel> bookBaseRepository, 
            IMappingService mappingService, IDataSorting dataSorting, ILoggedAccount loggedAccount, IUserAuthenticationService userAuthenticationService, 
            IValidationService validationService, IUserRepository userRepository, SignInPanelViewModel signInPanelViewModel)
        {
            _libraryVM = libraryVM;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataSorting = dataSorting;
            _loggedAccount = loggedAccount;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _signInPanelViewModel = signInPanelViewModel;
        }
    }
}
