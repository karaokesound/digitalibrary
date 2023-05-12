using Library.UI.Model;
using System;

namespace Library.Models.Model
{
    public class AuthorBook
    {
        public Guid AuthorId { get; set; }
        public AuthorModel Author { get; set; }

        public Guid BookId { get; set; }
        public BookModel Book { get; set; }
    }
}
