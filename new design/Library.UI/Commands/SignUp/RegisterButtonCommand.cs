﻿using Library.Data;
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

        private readonly IUserRepository _userRepository;

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

            bool dataValidation = ValidationService.SignUpValidation(newAccount);
            if (dataValidation == false)
            {
                return;
            }
            _userRepository.InsertUser(newAccount);
            _signUpPanelVM.SignUpPanelVisibility = false;
            _signUpPanelVM.MainWindowButtonVisibility = true;
            _signUpPanelVM.NewAccount.Username = string.Empty;
            _signUpPanelVM.NewAccount.Password = string.Empty;
            _signUpPanelVM.NewAccount.FirstName = string.Empty;
            _signUpPanelVM.NewAccount.LastName = string.Empty;
            _signUpPanelVM.NewAccount.Email = string.Empty;
            _signUpPanelVM.NewAccount.City = string.Empty;
            _signUpPanelVM.NewAccount.Library = string.Empty;
        }

        public RegisterButtonCommand(SignUpPanelViewModel signUpPanelVM, IUserRepository userRepository)
        {
            _signUpPanelVM = signUpPanelVM;
            _userRepository = userRepository;
        }
    }
}