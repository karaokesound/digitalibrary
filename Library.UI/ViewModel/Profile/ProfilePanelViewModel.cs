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

        public ICommand ProfileUpdateViewCommand { get; }

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataFiltering;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        public ProfilePanelViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService, IDataSorting dataFiltering,
            IUserAuthenticationService userAuthenticationService, IValidationService validationService, IUserRepository userRepository,
            IBaseRepository<AccountModel> accountBaseRepository, IAccountBookRepository accountBookRepository)
        {
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataFiltering = dataFiltering;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            ProfileUpdateViewCommand = new ProfileUpdateViewCommand(this, _bookBaseRepository, _mappingService, _dataFiltering,
                _userAuthenticationService, _validationService, _userRepository, _accountBaseRepository, _accountBookRepository);
        }
    }
}
