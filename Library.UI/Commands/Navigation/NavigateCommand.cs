using Library.UI.Command;
using Library.UI.Service;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Navigation
{
    public class NavigateCommand<TViewModel> : CommandBase
       where TViewModel : BaseViewModel
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
