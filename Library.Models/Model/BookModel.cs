using Library.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.UI.Model
{
    public class BookModel
    {
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public int Pages { get; set; }

        public ICollection<AuthorBook> AuthorBook { get; set; }
    }
}
