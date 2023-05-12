using Library.Models.Model;
using System;
using System.Collections.Generic;

namespace Library.UI.Model
{
    public class AuthorModel
    {
        public Guid AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<AuthorBook> AuthorBook { get; set; }
    }
}
