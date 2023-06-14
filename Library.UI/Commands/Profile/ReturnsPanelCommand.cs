using Library.UI.Command;
using Library.UI.Service.Validation;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Profile
{
    public class ReturnsPanelCommand : CommandBase
    {
        private readonly ProfilePanelViewModel _profilePanelViewModel;

        private readonly IElementVisibilityService _elementVisibilityService;

        public override void Execute(object parameter)
        {
            bool isClicked = true;

            _elementVisibilityService.AdjustReturnsPanelVisibility(isClicked);
            _profilePanelViewModel.IsReturnsPanelVisible = _elementVisibilityService.IsReturnsPanelClicked;
        }

        public ReturnsPanelCommand(ProfilePanelViewModel profilePanelViewModel, IElementVisibilityService elementVisibilityService)
        {
            _profilePanelViewModel = profilePanelViewModel;
            _elementVisibilityService = elementVisibilityService;
        }
    }
}
