using Library.UI.Data;
using Library.UI.ViewModel;
using System.Windows.Controls;

namespace Library.UI.View
{
    public partial class BookCollectionView : UserControl
    {
        private BookCollectionViewModel _bookCollectionVM;

        public BookCollectionView()
        {
            InitializeComponent();
            _bookCollectionVM = new BookCollectionViewModel(new BookDataProvider());
            DataContext = _bookCollectionVM;
        }
    }
}
