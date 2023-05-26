using Library.UI.Commands.Library;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using Library.UI.ViewModel.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

        private ObservableCollection<BookViewModel> _randomBookList;
        public ObservableCollection<BookViewModel> RandomBookList
        {
            get => _randomBookList;
            set 
            { 
                _randomBookList = value;
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

        private SortingMethod _sortingMethods;
        public SortingMethod SortingMethods
        {
            get => _sortingMethods;
            set 
            { 
                _sortingMethods = value;
                OnPropertyChanged();
                
            }
        }

        private BookQuantity _quantity;
        public BookQuantity Quantity
        {
            get => _quantity;
            set 
            { 
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public ICommand LibraryUpdateViewCommand { get; }

        public ICommand SortBooksCommand { get; }

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataSorting;

        public LibraryViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService, 
            IDataSorting dataSorting)
        {
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataSorting = dataSorting;
            BookList = new ObservableCollection<BookViewModel>();
            RandomBookList = new ObservableCollection<BookViewModel>();
            SortBooksCommand = new SortBooksCommand(this, _dataSorting);
            LibraryUpdateViewCommand = new LibraryUpdateViewCommand(this);
            GenerateRandomBooks();
        }

        public void DisplayBooks(List<BookModel> sortedBookList)
        {
            BookList.Clear();

            foreach (var sortedBook in sortedBookList)
            {
                BookList.Add(_mappingService.BookModelToViewModel(sortedBook, sortedBook.Author));
            }
        }

        public void GenerateRandomBooks()
        {
            var mostPopularBooks = _bookBaseRepository.GetAll().Where(book => book.Downloads > 10000).ToList();

            Random randomBook = new Random();

            for (int i = 0; i < 3; i++)
            {
                int rnd = randomBook.Next(mostPopularBooks.Count);
                RandomBookList.Add(_mappingService.BookModelToViewModel(mostPopularBooks[rnd], mostPopularBooks[rnd].Author));
            }
        }

        public enum Genre
        {
            [Description("Category")]
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

        public enum SortingMethod
        {
            [Description("Sort")]
            NOT_SET = 0,
            [Description("A-z")]
            Az,
            [Description("Downloads")]
            Downloads
        }

        public enum BookQuantity
        {
            [Description("All")]
            NOT_SET = 0,
            [Description("5")]
            Five = 5,
            [Description("10")]
            Ten = 10,
            [Description("20")]
            Twenty = 20,
            [Description("40")]
            Fifty = 40
        }
    }
}
