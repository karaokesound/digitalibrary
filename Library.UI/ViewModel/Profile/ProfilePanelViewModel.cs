using Library.UI.Commands.Library;
using Library.UI.Commands.Profile;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class ProfilePanelViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        private AccountModel _loggedUser;
        public AccountModel LoggedUser
        {
            get => _loggedUser;
            set 
            { 
                _loggedUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand ProfileUpdateViewCommand { get; }

        public ICommand ReturnBookCommand { get; }

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataSorting;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        public ProfilePanelViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService, IDataSorting dataSorting,
            IUserAuthenticationService userAuthenticationService, IValidationService validationService, IUserRepository userRepository,
            IBaseRepository<AccountModel> accountBaseRepository, IAccountBookRepository accountBookRepository)
        {
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataSorting = dataSorting;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            //ReturnBookCommand = new ReturnBookCommand(this, _accountBaseRepository, _accountBookRepository, _mappingService, _bookBaseRepository,
            //    _dataSorting);
            ProfileUpdateViewCommand = new ProfileUpdateViewCommand(this, _bookBaseRepository, _mappingService, _dataSorting,
                _userAuthenticationService, _validationService, _userRepository, _accountBaseRepository, _accountBookRepository);
            TakeLoggedUserData();
        }

        public void TakeLoggedUserData()
        {
            LoggedUser = _userAuthenticationService.LoggedUser;
        }
    }
}
