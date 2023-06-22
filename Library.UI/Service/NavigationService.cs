using Library.UI.ViewModel;
using System;

namespace Library.UI.Service
{
    public class NavigationService<TViewModel> where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
