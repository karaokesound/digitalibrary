using Library.UI.Commands.Library;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Services;
using Library.UI.ViewModel.Library;
using System;
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

        public ICommand GetBookBaseCommand { get; }

        public ICommand DisplayBookCommand { get; }

        private readonly IBaseRepository<BookModel> _baseRepository;

        private readonly IMappingService _mappingService;

        public LibraryViewModel(IBaseRepository<BookModel> baseRepository, IMappingService mappingService)
        {
            LibraryUpdateViewCommand = new LibraryUpdateViewCommand(this);
            BookList = new ObservableCollection<BookViewModel>();

            _baseRepository = baseRepository;
            _mappingService = mappingService;
            GetBookBaseCommand = new GetBookBaseCommand(this, _mappingService);
            DisplayBookCommand = new DisplayBookCommand(this, _mappingService, _baseRepository);
        }

        public enum Genre
        {
            [Description("")]
            NOT_SET = 0,
            [Description("Adventure")]
            Adventure,
            [Description("Classics")]
            Classics,
            [Description("Crime")]
            Crime,
            [Description("Fairy tales")]
            Fairy_tales,
            [Description("Fantasy")]
            Fantasy,
            [Description("Historical fiction")]
            Historical_fiction,
            [Description("Horror")]
            Horror,
            [Description("Humour and satire")]
            Humour_and_satire,
            [Description("Literaly fiction")]
            Literary_fiction,
            [Description("Mystery")]
            Mystery,
            [Description("Poetry")]
            Poetry,
            [Description("Plays")]
            Plays,
            [Description("Romance")]
            Romance,
            [Description("Sci-fi")]
            Science_fiction,
            [Description("Short stories")]
            Short_stories,
            [Description("Thrillers")]
            Thrillers,
            [Description("War")]
            War,
            [Description("Womens fiction")]
            Womens_fiction,
            [Description("Young adult")]
            Young_adult
        }
    }
}
