using System;
using System.ComponentModel.DataAnnotations;

namespace Library.UI.Model
{
    public class BookModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public AuthorModel Author { get; set; }

        public string Category { get; set; }

        public int Pages { get; set; }
    }
}
