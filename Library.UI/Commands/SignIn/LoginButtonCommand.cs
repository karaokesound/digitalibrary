using Library.Data;
using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System;
using System.Linq;
using System.Windows;

namespace Library.UI.Commands.SignIn
{
    public class LoginButtonCommand : CommandBase
    {
        private readonly SignInPanelViewModel _signInPanelVM;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IUserRepository _userRepository;

        public override void Execute(object parameter)
        {
            UserViewModel user = _signInPanelVM.SignInUsernamePassword;
            UserModel dataBaseUser = null;

            dataBaseUser = _userRepository.GetUserByUsername(user.Username) as UserModel;
            if (dataBaseUser == null)
            {
                MessageBox.Show("Incorrect username or password. Forgot password?", "Login");
                return;
            }

            //var users = _baseRepository.GetAll();
            //foreach (var dbu in users)
            //{
            //    if (dbu.Username == user.Username) dataBaseUser = dbu;
            //    MappingService.UserModelToViewModel(dbu);
            //}

            //if (dataBaseUser == null) 
            //{
            //    MessageBox.Show("Incorrect username or password. Forgot password?", "Login");
            //    return;
            //} 

            bool validation = ValidationService.SignInValidation(dataBaseUser, user);
            if (validation == false)
            {
                return;
            }
            _userAuthenticationService.Authentication(user.Username, dataBaseUser.Username, user.Password,
                dataBaseUser.Password);
            _signInPanelVM.RaiseUserAuthEvent();
        }

        public LoginButtonCommand(SignInPanelViewModel signInPanelVM, IUserAuthenticationService
            userAuthenticationService, IUserRepository userRepository)
        {
            _signInPanelVM = signInPanelVM;
            _userAuthenticationService = userAuthenticationService;
            _userRepository = userRepository;
        }
    }
}
