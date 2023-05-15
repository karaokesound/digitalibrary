using Library.UI.Commands.Library;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class LibraryViewModel : BaseViewModel
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

        public ICommand LibraryUpdateViewCommand { get; }

        public LibraryViewModel()
        {
            LibraryUpdateViewCommand = new LibraryUpdateViewCommand(this);
        }
    }
}
