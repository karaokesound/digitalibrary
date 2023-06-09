﻿using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Services;
using Library.UI.ViewModel;
using System;
using System.Windows.Controls;

namespace Library.UI.Commands
{
    public class RegisterCommand : CommandBase
    {
        private readonly SignUpPanelViewModel _signUpPanelVM;

        private readonly IValidationService _validationService;

        private readonly IBaseRepository<AccountModel> _baseRepository;

        public override void Execute(object parameter)
        {
            AccountModel newAccount = new AccountModel()
            {
                AccountId = Guid.NewGuid(),
                Username = _signUpPanelVM.NewAccount.Username,
                Password = _signUpPanelVM.NewAccount.Password,
                FirstName = _signUpPanelVM.NewAccount.FirstName,
                LastName = _signUpPanelVM.NewAccount.LastName,
                Email = _signUpPanelVM.NewAccount.Email,
                City = _signUpPanelVM.NewAccount.City,
                Library = _signUpPanelVM.NewAccount.Library,
                MaxBookQntToRent = 5,
                AccountBooks = _signUpPanelVM.NewAccount.AccountBooks,
            };

            ComboBoxItem selectedItem = parameter as ComboBoxItem;
            if (selectedItem != null)
            {
                _signUpPanelVM.NewAccount.Library = selectedItem.Content.ToString();
            }

            bool dataValidation = _validationService.SignUpValidation(newAccount);
            if (!dataValidation)
            {
                return;
            }

            _baseRepository.Insert(newAccount);
            _baseRepository.Save();

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

        public RegisterCommand(SignUpPanelViewModel signUpPanelVM, IValidationService validationService, 
            IBaseRepository<AccountModel> baseRepository)
        {
            _signUpPanelVM = signUpPanelVM;
            _validationService = validationService;
            _baseRepository = baseRepository;
        }
    }
}
