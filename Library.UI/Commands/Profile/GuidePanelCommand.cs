using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Profile
{
    public class GuidePanelCommand : CommandBase
    {
        private readonly ProfilePanelViewModel _profilePanelVM;

        public override void Execute(object parameter)
        {
            _profilePanelVM.IsGuidePanelVisible = true;
        }

        public GuidePanelCommand(ProfilePanelViewModel profilePanelVM)
        {
            _profilePanelVM = profilePanelVM;
        }
    }
}
