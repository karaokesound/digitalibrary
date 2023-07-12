using Library.UI.Command;
using Library.UI.Service.Validation;
using Library.UI.ViewModel;

namespace Library.UI.Commands
{
    public class SignUpButtonCommand : CommandBase
    {
        private readonly SignUpPanelViewModel _signUpPanelVM;

        private readonly IElementVisibilityService _notUsedElementHidingService;

        private readonly SignInPanelViewModel _signInPanelVM;

        public override void Execute(object parameter)
        {
            _signInPanelVM.LoggingUsernamePassword.Username = string.Empty;
            _signInPanelVM.LoggingUsernamePassword.Password = string.Empty;

            _signUpPanelVM.MainWindowButtonVisibility = false;
            _signUpPanelVM.SignUpPanelVisibility = true;
            _notUsedElementHidingService.AdjustElementVisibility(_signUpPanelVM.SignUpPanelVisibility);
            _signUpPanelVM.RaiseSignUpButtClickedEvent();
        }

        public SignUpButtonCommand(SignUpPanelViewModel signUpPanelVM, IElementVisibilityService notUsedElementHidingService,
            SignInPanelViewModel signInPanelVM)
        {
            _signUpPanelVM = signUpPanelVM;
            _notUsedElementHidingService = notUsedElementHidingService;
            _signInPanelVM = signInPanelVM;
        }
    }
}
