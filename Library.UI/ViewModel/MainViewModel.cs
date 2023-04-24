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

		public LofiCollectionViewModel LofiCollectionVM { get; }

		public ICommand UpdateViewCommand { get; }

        public MainViewModel()
        {
			UpdateViewCommand = new UpdateViewCommand(this);
			//SelectedViewModel = new BookCollectionViewModel(new BookDataProvider());
		}
    }
}
