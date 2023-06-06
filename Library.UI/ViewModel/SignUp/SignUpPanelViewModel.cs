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

        private UserViewModel _newAccount;
        public UserViewModel NewAccount
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

        public ICommand RegisterButtonCommand { get; }

        public ICommand ExitButtonCommand { get; }

        private readonly IValidationService _validationService;

        private readonly IBaseRepository<UserModel> _baseRepository;

        private readonly INotUsedElementHidingService _notUsedElementHidingService;

        public SignUpPanelViewModel(IValidationService validationService, IBaseRepository<UserModel> baseRepository,
            INotUsedElementHidingService notUsedElementHidingService)
        {
            _validationService = validationService;
            _baseRepository = baseRepository;
            _notUsedElementHidingService = notUsedElementHidingService;
            SignUpButtonCommand = new SignUpButtonCommand(this, _notUsedElementHidingService);
            ExitButtonCommand = new ExitButtonCommand(this, _notUsedElementHidingService);
            RegisterButtonCommand = new RegisterButtonCommand(this, _validationService, _baseRepository);
            NewAccount = new UserViewModel(_validationService);
            LibraryList = new ObservableCollection<string>();
            _libraryList.Add("Vice ELibrary");
            _libraryList.Add("NightC -DLibrary");
        }

        public void RaiseSignUpButtClickedEvent() => SignUpButtonClicked?.Invoke(_notUsedElementHidingService.IsSignUpButtonClicked);
    }
}
