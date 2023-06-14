using Library.Models.Model;
using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Service.Validation;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System.Windows;

namespace Library.UI.Commands.Library
{
    public class ReturnBookCommand : CommandBase
    {
        private readonly ProfilePanelViewModel _profilePanelViewModel;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        private readonly IMappingService _mappingService;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IDataSorting _dataSorting;
        private readonly IElementVisibilityService _elementVisibilityService;

        public override void Execute(object parameter)
        {
            if (_profilePanelViewModel.SelectedBook == null) return;

            BookViewModel selectedBookVM = _profilePanelViewModel.SelectedBook.Book;
            BookModel selectedBook = _mappingService.BookViewModelToModel(selectedBookVM, selectedBookVM.Author);

            AccountModel dbLoggedUser = _accountBaseRepository.GetByID(_profilePanelViewModel.LoggedUser.AccountId);
            BookModel dbSelecteedBook = _bookBaseRepository.GetByID(selectedBook.BookId);

            dbLoggedUser.MaxBookQntToRent += 1;

            AccountBookModel returningBook = _accountBookRepository.GetUserBookByID(dbLoggedUser.AccountId, selectedBook.BookId);

            if (returningBook == null)
            {
                MessageBox.Show("You didn't rent this book.");
                return;
            }

            returningBook.Quantity -= 1;

            if (returningBook.Quantity == 0)
            {
                _accountBookRepository.DeleteUserBook(dbLoggedUser.AccountId, returningBook.BookId);

                dbSelecteedBook.IsRented = false;
                dbSelecteedBook.Quantity += 1;
            }

            

            _accountBaseRepository.Save();
            _accountBookRepository.Save();
            _bookBaseRepository.Save();

            _profilePanelViewModel.TakeLoggedUserData();
            _profilePanelViewModel.RemoveUserRentedBook(dbSelecteedBook);
        }

        public ReturnBookCommand(ProfilePanelViewModel profilePanelViewModel, IBaseRepository<AccountModel> accountBaseRepository,
            IAccountBookRepository accountBookRepository, IMappingService mappingService, IBaseRepository<BookModel> bookBaseRepository,
            IDataSorting dataSorting, IElementVisibilityService elementVisibilityService)
        {
            _profilePanelViewModel = profilePanelViewModel;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
            _mappingService = mappingService;
            _bookBaseRepository = bookBaseRepository;
            _dataSorting = dataSorting;
            _elementVisibilityService = elementVisibilityService;
        }
    }
}
