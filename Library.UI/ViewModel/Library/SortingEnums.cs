using System.ComponentModel;

namespace Library.UI.ViewModel.Library
{
    public class SortingEnums : BaseViewModel 
    {
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

        private AlphabeticalSorting _alphabeticalSorting;
        public AlphabeticalSorting AlphabeticalSortingMethod
        {
            get => _alphabeticalSorting;
            set
            {
                _alphabeticalSorting = value;
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

        public enum Genre
        {
            [Description(" ")]
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
            [Description(" ")]
            NOT_SET = 0,
            [Description("A-z")]
            Az,
            [Description("Downloads")]
            Downloads,
            [Description("Copies")]
            Copies,
        }

        public enum AlphabeticalSorting
        {
            NOT_SET = 0,
            [Description("Books")]
            Books,
            [Description("Authors")]
            Authors
        }

        public enum BookQuantity
        {
            [Description(" ")]
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
