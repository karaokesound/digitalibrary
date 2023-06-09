using System;
using System.Collections.Generic;
using System.Windows.Documents;

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

        public int MaxQntOfRentedBooks { get; set; }

        public ICollection<Guid> RentedBooks { get; set; }
    }
}
