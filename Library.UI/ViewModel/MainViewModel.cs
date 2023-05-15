using Library.UI.Commands;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
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
		public AccountPanelViewModel AccountPanelVM { get; }

        public SignUpPanelViewModel SignUpPanelVM { get; }

        public SignInPanelViewModel SignInPanelVM { get; }

		public LibraryViewModel LibraryVM { get; }

		private bool _isUserAuthenticated;

        public bool IsUserAuthenticated
		{
			get => _isUserAuthenticated;
			set 
			{ 
				_isUserAuthenticated = value;
				OnPropertyChanged();
			}
		}

        public ICommand UpdateViewCommand { get; }

        public MainViewModel(AccountPanelViewModel accountPanelVM, SignUpPanelViewModel signUpPanelVM, SignInPanelViewModel signInPanelVM,
			LibraryViewModel libraryVM)
        {
			UpdateViewCommand = new UpdateViewCommand(this);
			AccountPanelVM = accountPanelVM;
			SignUpPanelVM = signUpPanelVM;
			SignInPanelVM = signInPanelVM;
			LibraryVM = libraryVM;

			SelectedViewModel = new LibraryViewModel();

			// login button //
            SignInPanelVM.UserAuthenticationChanged += (isUserAuthenticated) =>
			{
				IsUserAuthenticated = isUserAuthenticated;
				if (IsUserAuthenticated == true)
				{
					SelectedViewModel = new AccountPanelViewModel();
				}
				else return;
			};
		}
    }
}
