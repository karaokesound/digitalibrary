using Library.UI.ViewModel;
using System;

namespace Library.UI.Stores
{
    public class NavigationStore : BaseViewModel
    {
        public event Action CurrentViewModelChanged;

        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
