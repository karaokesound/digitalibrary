using Library.UI.Commands.Account;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Service.Data;
using Library.UI.Services;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class AccountPanelViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IMappingService _mappingService;

        private readonly IDataSorting _dataFiltering;

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set 
            { 
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand AccountUpdateViewCommand { get; }

        public AccountPanelViewModel(IBaseRepository<BookModel> bookBaseRepository, IMappingService mappingService, IDataSorting dataFiltering)
        {
            _bookBaseRepository = bookBaseRepository;
            _mappingService = mappingService;
            _dataFiltering = dataFiltering;
            AccountUpdateViewCommand = new AccountUpdateViewCommand(this, _bookBaseRepository, _mappingService, _dataFiltering);
        }
    }
}
