using Library.UI.Commands.Library;
using Library.UI.Model;
using Library.UI.Service;
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

        //public ICommand GetBookBaseCommand { get; }

        //public ICommand DisplayBookCommand { get; }

        private readonly IBaseRepository<BookModel> _baseRepository;

        private readonly IMappingService _mappingService;

        public LibraryViewModel(IBaseRepository<BookModel> baseRepository, IMappingService mappingService)
        {
            _baseRepository = baseRepository;
            _mappingService = mappingService;
            BookList = new ObservableCollection<BookViewModel>();
            LibraryUpdateViewCommand = new LibraryUpdateViewCommand(this);
            DisplayBooks();
            //GetBookBaseCommand = new GetBookBaseCommand(this, _mappingService);
            //DisplayBookCommand = new DisplayBookCommand(this, _mappingService, _baseRepository);
        }

        public void DisplayBooks()
        {
            List<BookModel> bookList = _baseRepository.GetAll().ToList();

            foreach (BookModel book in bookList)
            {
                BookList.Add(_mappingService.BookModelToViewModel(book));
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
