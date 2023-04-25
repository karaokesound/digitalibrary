using Library.UI.Model;
using System;
using System.Collections.Generic;

namespace Library.UI.Data
{
    public class BookDataProvider : IBookDataProvider
    {
        public List<Book> GetAllBooks()
        {
            return new List<Book>
            {
                new Book { Id = Guid.NewGuid(), Title = "The Hobbit", Pages = 230, Volume = 1},
                new Book { Id = Guid.NewGuid(), Title = "The Lion, the Witch and the Wardrobe", Pages = 314, Volume = 1},
                new Book { Id = Guid.NewGuid(), Title = "The Da Vinci Code", Pages = 402, Volume = 1},
                new Book { Id = Guid.NewGuid(), Title = "The Alchemist", Pages = 350, Volume = 1},
                new Book { Id = Guid.NewGuid(), Title = "Harry Potter and the Prisoner of Azkaban", Pages = 552, Volume = 1},
                new Book { Id = Guid.NewGuid(), Title = "Angels & Demons", Pages = 190, Volume = 1},
                new Book { Id = Guid.NewGuid(), Title = "The Great Gatsby", Pages = 210, Volume = 1},
                new Book { Id = Guid.NewGuid(), Title = "The Hunger Games", Pages = 214, Volume = 1},
                new Book { Id = Guid.NewGuid(), Title = "Love Story", Pages = 272, Volume = 1},
            };
        }
    }
}
