using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System.Linq;
using System.Windows;

namespace Library.UI.Commands.Library
{
    public class RentBookCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IDataSorting _dataSorting;

        private readonly IMappingService _mappingService;

        public override void Execute(object parameter)
        {
            BookViewModel rentedBookVM = _libraryViewModel.BookList.FirstOrDefault(b => b.BookId == _libraryViewModel.SelectedBook.BookId);
            BookModel rentedBook = _mappingService.BookViewModelToModel(rentedBookVM, rentedBookVM.Author);

            BookModel dbBook = _bookBaseRepository.GetByID(rentedBook.BookId);

            // Database operations
            dbBook.IsRented = true;
            
            if (rentedBook.Quantity == 0)
            {
                MessageBox.Show("You can't rent this book. We don't have any copy in the library. Send request to rent this book if available");
                return;
            }

            dbBook.Quantity = dbBook.Quantity - 1;
            _bookBaseRepository.Save();

            // ViewModel operations
            var resortedBooks = _dataSorting.SortBooks(SortingEnums.SortingMethod.NOT_SET, SortingEnums.BookQuantity.NOT_SET, SortingEnums.Genre.NOT_SET);
            _libraryViewModel.DisplayBooks(resortedBooks);


        }

        public RentBookCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookModel> bookBaseRepository, IDataSorting dataSorting,
            IMappingService mappingService)
        {
            _libraryViewModel = libraryViewModel;
            _bookBaseRepository = bookBaseRepository;
            _dataSorting = dataSorting;
            _mappingService = mappingService;
        }
    }
}
