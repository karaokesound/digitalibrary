using System;
using System.ComponentModel.DataAnnotations;

namespace Library.UI.Model
{
    public class BookModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public AuthorModel Author { get; set; }

        public int? Volume { get; set; }
        
        public int Pages { get; set; }
    }
}
