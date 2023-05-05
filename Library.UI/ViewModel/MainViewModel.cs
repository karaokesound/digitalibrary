using Library.Data;
using Library.UI.Commands;
using Library.UI.Services;
using System;
using System.Windows;
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

		public BookCollectionViewModel BookCollectionVM { get; }

		public AccountPanelViewModel AccountPanelVM { get; }

        public SignUpPanelViewModel SignUpPanelVM { get; }

        public SignInPanelViewModel SignInPanelVM { get; }

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

        public MainViewModel(AccountPanelViewModel accountPanelVM, BookCollectionViewModel bookCollectionVM,
			SignUpPanelViewModel signUpPanelVM, SignInPanelViewModel signInPanelVM)
        {
			UpdateViewCommand = new UpdateViewCommand(this);
			AccountPanelVM = accountPanelVM;
			BookCollectionVM = bookCollectionVM;
			SignUpPanelVM = signUpPanelVM;
			SignInPanelVM = signInPanelVM;
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
