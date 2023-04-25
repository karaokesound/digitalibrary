using Library.UI.Commands;
using System.Windows.Input;

namespace Library.UI.ViewModel
{
    public class SignUpViewModel : BaseViewModel
    {
        private bool _signUpPanelVisibility;
        public bool SignUpPanelVisibility 
        {
            get => _signUpPanelVisibility;
            set 
            { 
                _signUpPanelVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignUpCommand { get; }

        public SignUpViewModel()
        {
            SignUpCommand = new SignUpCommand(this);
        }
    }
}
