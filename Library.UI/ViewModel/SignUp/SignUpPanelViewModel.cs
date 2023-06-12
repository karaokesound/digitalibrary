using Library.UI.Commands;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Validation;
using Library.UI.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class SignUpPanelViewModel : BaseViewModel
    {
        public delegate void SignUpButtonClickedEvent(bool isSignUpButtonClicked);

        public event SignUpButtonClickedEvent SignUpButtonClicked = null;

        private bool _signUpPanelVisibility;
        public bool SignUpPanelVisibility
        {
            get => _signUpPanelVisibility;
            set
            {
                _signUpPanelVisibility = value;
                OnPropertyChanged();
            }
        }

        private bool _mainWindowButtonVisibility = true;
        public bool MainWindowButtonVisibility
        {
            get => _mainWindowButtonVisibility;
            set
            {
                _mainWindowButtonVisibility = value;
                OnPropertyChanged();
            }
        }

        private AccountViewModel _newAccount;
        public AccountViewModel NewAccount
        {
            get { return _newAccount; }
            set
            {
                _newAccount = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _libraryList;
        public ObservableCollection<string> LibraryList
        {
            get => _libraryList;
            set
            {
                _libraryList = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignUpButtonCommand { get; }

        public ICommand RegisterCommand { get; }

        public ICommand ExitButtonCommand { get; }

        private readonly IValidationService _validationService;

        private readonly IBaseRepository<AccountModel> _baseRepository;

        private readonly IElementVisibilityService _elementVisibilityService;

        public SignUpPanelViewModel(IValidationService validationService, IBaseRepository<AccountModel> baseRepository,
            IElementVisibilityService elementVisibilityService)
        {
            _validationService = validationService;
            _baseRepository = baseRepository;
            _elementVisibilityService = elementVisibilityService;
            SignUpButtonCommand = new SignUpButtonCommand(this, _elementVisibilityService);
            ExitButtonCommand = new ExitButtonCommand(this, _elementVisibilityService);
            RegisterCommand = new RegisterCommand(this, _validationService, _baseRepository);
            NewAccount = new AccountViewModel(_validationService);
            LibraryList = new ObservableCollection<string>();
            _libraryList.Add("Vice ELibrary");
            _libraryList.Add("NightC -DLibrary");
        }

        public void RaiseSignUpButtClickedEvent() => SignUpButtonClicked?.Invoke(_elementVisibilityService.IsSignUpButtonClicked);
    }
}
