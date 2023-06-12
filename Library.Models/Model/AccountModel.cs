using Library.Models.Model;
using System;
using System.Collections.Generic;

namespace Library.UI.Model
{
    public class AccountModel
    {
        public Guid AccountId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Library { get; set; }

        public int MaxBookQntToRent { get; set; }

        public ICollection<AccountBookModel> AccountBooks { get; set; }
    }
}
