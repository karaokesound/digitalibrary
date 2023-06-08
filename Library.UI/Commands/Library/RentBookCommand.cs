using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System.Windows;

namespace Library.UI.Commands.Library
{
    public class RentBookCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        public override void Execute(object parameter)
        {
            MessageBox.Show($"Rent {_libraryViewModel.SelectedBook.Title} ?");
            
        }

        public RentBookCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookModel> bookBaseRepository)
        {
            _libraryViewModel = libraryViewModel;
            _bookBaseRepository = bookBaseRepository;
        }
    }
}
