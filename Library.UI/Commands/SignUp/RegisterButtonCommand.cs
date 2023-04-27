using Library.UI.Command;
using Library.UI.Model;
using Library.UI.ViewModel;
using System.Windows.Controls;

namespace Library.UI.Commands
{
    public class RegisterButtonCommand : CommandBase
    {
        private readonly SignUpPanelViewModel _signUpPanelVM;

        public override void Execute(object parameter)
        {
            SignUpModel newAccount = new SignUpModel()
            {
                FirstName = _signUpPanelVM.NewAccount.FirstName,
                LastName = _signUpPanelVM.NewAccount.LastName,
                Email = _signUpPanelVM.NewAccount.Email,
                City = _signUpPanelVM.NewAccount.City,
                Library = _signUpPanelVM.NewAccount.Library,
            };

            ComboBoxItem selectedItem = parameter as ComboBoxItem;
            if (selectedItem != null)
            {
                // przypisz wartość Content wybranego elementu do zmiennej Library w SignUpItemViewModel
                _signUpPanelVM.NewAccount.Library = selectedItem.Content.ToString();
            }
        }

        public RegisterButtonCommand(SignUpPanelViewModel signUpPanelVM)
        {
            _signUpPanelVM = signUpPanelVM;
        }
    }
}
