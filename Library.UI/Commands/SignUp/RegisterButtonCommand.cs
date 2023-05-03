using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System;
using System.Windows.Controls;

namespace Library.UI.Commands
{
    public class RegisterButtonCommand : CommandBase
    {
        private readonly SignUpPanelViewModel _signUpPanelVM;

        public override void Execute(object parameter)
        {
            UserModel newAccount = new UserModel()
            {
                Id = Guid.NewGuid(),
                Username = _signUpPanelVM.NewAccount.Username,
                Password = _signUpPanelVM.NewAccount.Password,
                FirstName = _signUpPanelVM.NewAccount.FirstName,
                LastName = _signUpPanelVM.NewAccount.LastName,
                Email = _signUpPanelVM.NewAccount.Email,
                City = _signUpPanelVM.NewAccount.City,
                Library = _signUpPanelVM.NewAccount.Library,
            };

            ComboBoxItem selectedItem = parameter as ComboBoxItem;
            if (selectedItem != null)
            {
                _signUpPanelVM.NewAccount.Library = selectedItem.Content.ToString();
            }

            bool dataValidation = UserStoreService.AreUserDataValid(newAccount);
            if (dataValidation == true)
            {
                UserStoreService.AddUser(newAccount);
                _signUpPanelVM.SignUpPanelVisibility = false;
                _signUpPanelVM.MainWindowButtonVisibility = true;
            }
            return;
        }

       



        public RegisterButtonCommand(SignUpPanelViewModel signUpPanelVM)
        {
            _signUpPanelVM = signUpPanelVM;
        }
    }
}
