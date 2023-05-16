using Library.UI.Commands;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Services;
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

        public MainViewModel(AccountPanelViewModel accountPanelVM, SignUpPanelViewModel signUpPanelVM, SignInPanelViewModel signInPanelVM,
			LibraryViewModel libraryVM)
        {
			AccountPanelVM = accountPanelVM;
			SignUpPanelVM = signUpPanelVM;
			SignInPanelVM = signInPanelVM;
			LibraryVM = libraryVM;

			//SelectedViewModel = new LibraryViewModel(new BaseRepository<BookModel>(), new BookDatabase(), new MappingService(new ValidationService()));

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
