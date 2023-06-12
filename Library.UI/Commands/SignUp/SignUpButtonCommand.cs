using Library.UI.Command;
using Library.UI.Service.Validation;
using Library.UI.ViewModel;

namespace Library.UI.Commands
{
    public class SignUpButtonCommand : CommandBase
    {
        private readonly SignUpPanelViewModel _signUpPanelVM;

        private readonly IElementVisibilityService _notUsedElementHidingService;

        public override void Execute(object parameter)
        {
            
            _signUpPanelVM.MainWindowButtonVisibility = false;
            _signUpPanelVM.SignUpPanelVisibility = true;
            _notUsedElementHidingService.AdjustElementVisibility(_signUpPanelVM.SignUpPanelVisibility);
            _signUpPanelVM.RaiseSignUpButtClickedEvent();
        }

        public SignUpButtonCommand(SignUpPanelViewModel signUpPanelVM, IElementVisibilityService notUsedElementHidingService)
        {
            _signUpPanelVM = signUpPanelVM;
            _notUsedElementHidingService = notUsedElementHidingService;
        }
    }
}
