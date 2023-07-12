using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Profile
{
    public class ManagePanelCommand : CommandBase
    {
        private readonly ProfilePanelViewModel _profilePanelViewModel;

        public override void Execute(object parameter)
        {
            _profilePanelViewModel.IsManagePanelVisible = true;
        }

        public ManagePanelCommand(ProfilePanelViewModel profilePanelViewModel)
        {
            _profilePanelViewModel = profilePanelViewModel;
        }
    }
}
