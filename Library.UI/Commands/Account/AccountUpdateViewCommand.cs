using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service.Data;
using Library.UI.Service;
using Library.UI.Services;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Account
{
    public class AccountUpdateViewCommand : CommandBase
    {
        private readonly AccountPanelViewModel _accountPanelVM;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataFiltering;

        public AccountUpdateViewCommand(AccountPanelViewModel accountPanelVM, IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService,
            IDataSorting dataFiltering)
        {
            _accountPanelVM = accountPanelVM;
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataFiltering = dataFiltering;
        }

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Library")
            {
                _accountPanelVM.SelectedViewModel = new LibraryViewModel(_bookBaseRepository, _mappingService, _dataFiltering);
            }
        }
    }
}
