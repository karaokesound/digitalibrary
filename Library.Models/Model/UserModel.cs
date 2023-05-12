using System;

namespace Library.UI.Model
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Library { get; set; }
    }
}
