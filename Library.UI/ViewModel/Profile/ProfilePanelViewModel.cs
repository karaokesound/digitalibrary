using Library.UI.Commands.Profile;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Service.SignIn;
using Library.UI.Services;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class ProfilePanelViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataFiltering;

        private readonly ILoggedAccount _loggedAccount;

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set 
            { 
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ProfileUpdateViewCommand { get; }

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly SignInPanelViewModel _signInPanelViewModel;

        public ProfilePanelViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService, IDataSorting dataFiltering,
            ILoggedAccount loggedAccount, IUserAuthenticationService userAuthenticationService, IValidationService validationService, 
            IUserRepository userRepository, SignInPanelViewModel signInPanelViewModel)
        {
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataFiltering = dataFiltering;
            _loggedAccount = loggedAccount;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _signInPanelViewModel = signInPanelViewModel;
            ProfileUpdateViewCommand = new ProfileUpdateViewCommand(this, _bookBaseRepository, _mappingService, _dataFiltering, _loggedAccount,
                _userAuthenticationService, _validationService, _userRepository, _signInPanelViewModel);
        }
    }
}
