using Library.UI.Command;
using Library.UI.Service.Validation;
using Library.UI.ViewModel;
using System.Windows;

namespace Library.UI.Commands
{
    public class ExitButtonCommand : CommandBase
    {
        private readonly SignUpPanelViewModel _signUpPanelVM;

        private readonly IElementVisibilityService _notUsedElementHidingService;

        public override void Execute(object parameter)
        {
            MessageBoxButton messageBoxButtons = MessageBoxButton.YesNo;
            string title = "Close";
            string message = "If you close this window, you will lost all data. Are you sure?";
            MessageBoxResult result = MessageBox.Show(message, title, messageBoxButtons, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _signUpPanelVM.SignUpPanelVisibility = false;
                _signUpPanelVM.MainWindowButtonVisibility = true;
                _signUpPanelVM.NewAccount.Username = string.Empty;
                _signUpPanelVM.NewAccount.Password = string.Empty;
                _signUpPanelVM.NewAccount.FirstName = string.Empty;
                _signUpPanelVM.NewAccount.LastName = string.Empty;
                _signUpPanelVM.NewAccount.Email = string.Empty;
                _signUpPanelVM.NewAccount.City = string.Empty;
                _signUpPanelVM.NewAccount.Library = string.Empty;

                _notUsedElementHidingService.AdjustElementVisibility(_signUpPanelVM.SignUpPanelVisibility);
                _signUpPanelVM.RaiseSignUpButtClickedEvent();
            }

            else return;
        }

        public ExitButtonCommand(SignUpPanelViewModel signUpPanelVM, IElementVisibilityService notUsedElementHidingService)
        {
            _signUpPanelVM = signUpPanelVM;
            _notUsedElementHidingService = notUsedElementHidingService;
        }
    }
}
