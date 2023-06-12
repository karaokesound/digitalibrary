using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class LibraryUpdateViewCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryVM;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataSorting;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IValidationService _validationService;

        private readonly IUserRepository _userRepository;

        private readonly IBaseRepository<AccountModel> _accountBaseRepository;

        private readonly IAccountBookRepository _accountBookRepository;

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Profile")
            {
                _libraryVM.SelectedViewModel = new ProfilePanelViewModel(_bookBaseRepository, _mappingService, _dataSorting, 
                    _userAuthenticationService, _validationService, _userRepository, _accountBaseRepository, _accountBookRepository);
            }
        }

        public LibraryUpdateViewCommand(LibraryViewModel libraryVM, IBaseRepository<BookModel> bookBaseRepository, 
            IMappingService mappingService, IDataSorting dataSorting, IUserAuthenticationService userAuthenticationService, 
            IValidationService validationService, IUserRepository userRepository, IBaseRepository<AccountModel> accountBaseRepository,
            IAccountBookRepository accountBookRepository)
        {
            _libraryVM = libraryVM;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataSorting = dataSorting;
            _userAuthenticationService = userAuthenticationService;
            _validationService = validationService;
            _userRepository = userRepository;
            _accountBaseRepository = accountBaseRepository;
            _accountBookRepository = accountBookRepository;
        }
    }
}
