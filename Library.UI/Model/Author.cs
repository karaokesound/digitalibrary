using System;
using System.Collections.Generic;

namespace Library.UI.Model
{
    public class Author
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Book>? WrittenBooks { get; set; }

        public Author()
        {
            WrittenBooks = new List<Book>();
        }
    }
}
