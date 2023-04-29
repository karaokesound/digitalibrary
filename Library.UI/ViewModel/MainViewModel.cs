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

		public BookCollectionViewModel BookCollectionVM { get; }

		public AccountPanelViewModel AccountPanelVM { get; }

        public SignUpPanelViewModel SignUpPanelVM { get; }

        public SignInPanelViewModel SignInPanelVM { get; }

		public ICommand UpdateViewCommand { get; }

        public MainViewModel(AccountPanelViewModel accountPanelVM, BookCollectionViewModel bookCollectionVM,
			SignUpPanelViewModel signUpPanelVM, SignInPanelViewModel signInPanelVM)
        {
			UpdateViewCommand = new UpdateViewCommand(this);
			AccountPanelVM = accountPanelVM;
			BookCollectionVM = bookCollectionVM;
			SignUpPanelVM = signUpPanelVM;
			SignInPanelVM = signInPanelVM;
		}
    }
}
