using System;
using System.Collections.Generic;

namespace Library.UI.Model
{
    public class AuthorModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<BookModel>? WrittenBooks { get; set; }

        public AuthorModel()
        {
            WrittenBooks = new List<BookModel>();
        }
    }
}
