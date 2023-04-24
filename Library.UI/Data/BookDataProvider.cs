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
                new Book { Id = Guid.NewGuid(), Title = "Buszujacy w zbozu", Pages = 230},
                new Book { Id = Guid.NewGuid(), Title = "Buszujacy w zbozu", Pages = 230},
                new Book { Id = Guid.NewGuid(), Title = "Buszujacy w zbozu", Pages = 230},
            };
        }
    }
}
