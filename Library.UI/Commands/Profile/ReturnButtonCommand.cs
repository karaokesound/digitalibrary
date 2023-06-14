using Library.UI.Command;
using Library.UI.Service.Validation;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Profile
{
    public class ReturnButtonCommand : CommandBase
    {
        private readonly ProfilePanelViewModel _profilePanelViewModel;

        private readonly IElementVisibilityService _elementVisibilityService;

        public override void Execute(object parameter)
        {
            bool isClicked = false;

            _elementVisibilityService.AdjustReturnsPanelVisibility(isClicked);
            _profilePanelViewModel.IsReturnsPanelVisible = _elementVisibilityService.IsReturnsPanelClicked;
        }

        public ReturnButtonCommand(ProfilePanelViewModel profilePanelViewModel, IElementVisibilityService elementVisibilityService)
        {
            _profilePanelViewModel = profilePanelViewModel;
            _elementVisibilityService = elementVisibilityService;
        }
    }
}
