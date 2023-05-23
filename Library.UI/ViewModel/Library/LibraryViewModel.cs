using Library.UI.Commands.Library;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using Library.UI.ViewModel.Library;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        private Genre _genres;
        public Genre Genres
        {
            get { return _genres; }
            set
            {
                if (_genres != value)
                {
                    _genres = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LibraryUpdateViewCommand { get; }

        private readonly IMappingService _mappingService;

        private readonly IDataFiltering _dataFiltering;

        public LibraryViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService, 
            IDataFiltering dataFiltering)
        {
            _mappingService = mappingService;
            _dataFiltering = dataFiltering;
            BookList = new ObservableCollection<BookViewModel>();
            LibraryUpdateViewCommand = new LibraryUpdateViewCommand(this);
            DisplayBooks();
        }

        public void DisplayBooks()
        {
            // w przyszłości będzie to wyglądać tak, że będą komendy dla danej komendy filtrującej i komenda będzie robiła
            // wszystko co potrzeba, a następnie wysyłała dane do metody DisplayBooks(). Ta metoda w parametrze będzie
            // przyjmować zmienną, która powinna być taka sama dla wszystkich komend, czyli BookModel(). Komendy będą odsyłać
            // obiekty typu BookModel, a tutaj będzie pętla i zapisywanie do listy BookList.

            //var filteredBookList = _dataFiltering.SortBooksAlphabetical();
            //foreach (var filteredBook in filteredBookList)
            //{
            //    BookList.Add(_mappingService.BookModelToViewModel(filteredBook));
            //}

            var filteredBookList = _dataFiltering.DisplayInsertedNumberOfBooks();
            foreach (var filteredBook in filteredBookList)
            {
                BookList.Add(_mappingService.BookModelToViewModel(filteredBook));
            }
        }

        public enum Genre
        {
            [Description("")]
            NOT_SET = 0,
            [Description("Drama")]
            Drama,
            [Description("Fiction")]
            Fiction,
            [Description("Adventure stories")]
            Adventure_stories,
            [Description("Biography")]
            Biography,
            [Description("Historical fiction")]
            Historical_fiction,
            [Description("Juvenile fiction")]
            Juvenile_fiction,
            [Description("Autobiographical fiction")]
            Autobiographical_fiction,
            [Description("Comedies")]
            Comedies,
            [Description("Humor")]
            Humor,
            [Description("Feminist fiction")]
            Feminist_fiction,
            [Description("Horror tales")]
            Horror_tales,
            [Description("Poetry")]
            Poetry,
            [Description("Ethics")]
            Ethics,
            [Description("Life")]
            Life,
            [Description("Stoics")]
            Stoics,
            [Description("Romances")]
            Romances,
            [Description("Epic literature")]
            Epic_literature,
            [Description("Science fiction")]
            Science_fiction,
            [Description("Domestic fiction")]
            Domestic_fiction,
            [Description("Christmas stories")]
            Christmas_stories,
            [Description("Ghost stories")]
            Ghost_stories,
            [Description("Love stories")]
            Love_stories,
            [Description("Mysticism")]
            Mysticism,
            [Description("Fantasy literature")]
            Fantasy_literature,
            [Description("Calculus")]
            Calculus,
            [Description("Political fiction")]
            Political_fiction,
            [Description("Detective and mystery")]
            Detective_and_mystery_stories,
            [Description("Sabotage")]
            Sabotage,
            [Description("Bible")]
            Bible,
            [Description("French essays")]
            French_essays,
            [Description("Philosophy")]
            Philosophy,
            [Description("Gothic fiction")]
            Gothic_fiction,
            [Description("American drama")]
            American_drama,
            [Description("Communism")]
            Communism,
            [Description("Socialism")]
            Socialism,
            [Description("Fantasy fiction")]
            Fantasy_fiction,
            [Description("Liberty")]
            Liberty,
            [Description("Satire")]
            Satire,
            [Description("Adultery")]
            Adultery
        }
    }
}
