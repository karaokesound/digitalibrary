using System;

namespace Library.UI.Model
{
    public class BookModel
    {
        public Guid Id;

        public string Title { get; set; }

        public AuthorModel Author { get; set; }

        public int? Volume { get; set; }
        
        public int Pages { get; set; }
    }
}
