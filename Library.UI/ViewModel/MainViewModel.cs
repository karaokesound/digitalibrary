using Library.UI.Commands;
using Library.UI.Data;
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

		public ICommand UpdateViewCommand { get; }

        public MainViewModel(AccountPanelViewModel accountPanelVM, BookCollectionViewModel bookCollectionVM,
			SignUpPanelViewModel signUpVM)
        {
			UpdateViewCommand = new UpdateViewCommand(this);
			AccountPanelVM = accountPanelVM;
			BookCollectionVM = bookCollectionVM;
			SignUpPanelVM = signUpVM;
		}
    }
}
