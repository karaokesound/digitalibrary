using Library.UI.Commands;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class SignUpPanelViewModel : BaseViewModel
    {
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

        public SignUpPanelViewModel(IValidationService validationService, IBaseRepository<UserModel> baseRepository)
        {
            _validationService = validationService;
            _baseRepository = baseRepository;
            SignUpButtonCommand = new SignUpButtonCommand(this);
            ExitButtonCommand = new ExitButtonCommand(this);
            RegisterButtonCommand = new RegisterButtonCommand(this, _validationService, _baseRepository);
            NewAccount = new UserViewModel(_validationService);
            LibraryList = new ObservableCollection<string>();
            _libraryList.Add("Vice ELibrary");
            _libraryList.Add("NightC -DLibrary");
        }
    }
}
