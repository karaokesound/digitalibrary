using Library.UI.Commands;
using Library.UI.Model;
using Library.UI.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class SignUpPanelViewModel : BaseViewModel
    {
        private bool _signUpPanelVisibility; //= true; //SET TEMPORARY
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

        private SignUpViewModel _newAccount;
        public SignUpViewModel NewAccount
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

        public ICommand ExitButtonCommand { get; }

        public ICommand RegisterButtonCommand { get; }

        public SignUpPanelViewModel()
        {
            SignUpButtonCommand = new SignUpButtonCommand(this);
            ExitButtonCommand = new ExitButtonCommand(this);
            RegisterButtonCommand = new RegisterButtonCommand(this);
            NewAccount = new SignUpViewModel();
            LibraryList = new ObservableCollection<string>();
            _libraryList.Add("Test");
            _libraryList.Add("Test2");
        }
    }
}
