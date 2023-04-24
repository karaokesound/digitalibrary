using System;

namespace Library.UI.Model
{
    public class Book
    {
        public Guid Id;

        public string Title { get; set; }

        public Author Author { get; set; }

        public string? Volume { get; set; }
        
        public int Pages { get; set; }
    }
}
