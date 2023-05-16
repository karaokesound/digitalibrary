using Library.UI.Commands.Library;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Services;
using Library.UI.ViewModel.Library;
using System.Collections.ObjectModel;
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

        private ObservableCollection<BookViewModel> _bookList;
        public ObservableCollection<BookViewModel> BookList
        {
            get => _bookList;
            set
            {
                _bookList = value;
                OnPropertyChanged();
            }
        }

        public ICommand LibraryUpdateViewCommand { get; }

        public ICommand GetBookBaseCommand { get; }

        public ICommand DisplayBookCommand { get; }

        private readonly IBaseRepository<BookModel> _baseRepository;

        private readonly IBookDatabase _bookDatabase;

        private readonly IMappingService _mappingService;

        public LibraryViewModel(IBaseRepository<BookModel> baseRepository, IBookDatabase bookDatabase, IMappingService mappingService)
        {
            LibraryUpdateViewCommand = new LibraryUpdateViewCommand(this);
            BookList = new ObservableCollection<BookViewModel>();

            _baseRepository = baseRepository;
            _bookDatabase = bookDatabase;
            _mappingService = mappingService;
            GetBookBaseCommand = new GetBookBaseCommand(this, _bookDatabase, _mappingService);
            DisplayBookCommand = new DisplayBookCommand(this, _mappingService, _baseRepository);
        }

    }
}
