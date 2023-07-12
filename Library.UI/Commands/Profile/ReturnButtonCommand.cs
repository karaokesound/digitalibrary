using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Profile
{
    public class ReturnButtonCommand : CommandBase
    {
        private readonly ProfilePanelViewModel _profilePanelViewModel;

        public override void Execute(object parameter)
        {
            _profilePanelViewModel.IsManagePanelVisible = false;
            _profilePanelViewModel.IsGuidePanelVisible = false;
        }

        public ReturnButtonCommand(ProfilePanelViewModel profilePanelViewModel)
        {
            _profilePanelViewModel = profilePanelViewModel;
        }
    }
}
