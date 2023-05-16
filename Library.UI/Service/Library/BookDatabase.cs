using Library.UI.Model;
using Library.UI.Services;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Library.UI.Service
{
    public class BookDatabase : BaseRepository<BookModel>, IBookDatabase
    {
        public void InsertsBooksToDatabase()
        {
            AuthorModel author1 = new AuthorModel
            {
                AuthorId = Guid.NewGuid(),
                FirstName = "T.J.",
                LastName = "Klune"
            };

            BookModel book1 = new BookModel()
            {
                BookId = Guid.NewGuid(),
                Title = "In the Lives of Puppets",
                Category = BookModel.Genre.Science_fiction,
                Pages = 420,
            };
            book1.Authors = new List<AuthorModel>();
            book1.Authors.Add(author1);
            Insert(book1);
            Save();

            //BookModel book2 = new BookModel
            //{
            //    BookId = Guid.NewGuid(),
            //    Title = "Some Desperate Glory",
            //    Category = BookModel.Genre.Science_fiction,
            //    Pages = 438,
            //};
            //book1.Authors.Add(new AuthorModel { AuthorId = Guid.NewGuid(), FirstName = "Emily", LastName = "Tesh" });
            //Insert(book2);
            //Save();
        }

            //new BookModel { BookId = Guid.NewGuid(), Title = "In the Lives of Puppets", Category = BookModel.Genre.Science_fiction,
            //        Pages = 420,
            //        Authors = { new AuthorModel { AuthorId = Guid.NewGuid(), FirstName = "T.J.", LastName = "Klune" } } },
            //     new BookModel { BookId = Guid.NewGuid(), Title = "Some Desperate Glory", Category = BookModel.Genre.Science_fiction,
            //        Pages = 438,
            //        Authors = { new AuthorModel { AuthorId = Guid.NewGuid(), FirstName = "Emily", LastName = "Tesh" } } },

            //    new BookModel { BookId = Guid.NewGuid(), Title = "In the Lives of Puppets", Category = BookModel.Genre.Science_fiction,
            //        Pages = 420,
            //        Authors = { new AuthorModel { AuthorId = Guid.NewGuid(), FirstName = "T.J.", LastName = "Klune" } } },

            //    new BookModel { BookId = Guid.NewGuid(), Title = "Some Desperate Glory", Category = BookModel.Genre.Science_fiction,
            //        Pages = 438,
            //        Authors = { new AuthorModel { AuthorId = Guid.NewGuid(), FirstName = "Emily", LastName = "Tesh" } } },

            //    new BookModel { BookId = Guid.NewGuid(), Title = "Camp Zero", Category = BookModel.Genre.Science_fiction,
            //        Pages = 304,
            //        Authors = { new AuthorModel { AuthorId = Guid.NewGuid(), FirstName = "Michelle", LastName = "Min Sterling" } } },

            //    new BookModel { BookId = Guid.NewGuid(), Title = "Ascension", Category = BookModel.Genre.Science_fiction,
            //        Pages = 352,
            //        Authors = { new AuthorModel { AuthorId = Guid.NewGuid(), FirstName = "Nicholas", LastName = "Binge" } } },

            //    new BookModel { BookId = Guid.NewGuid(), Title = "Untethered Sky", Category = BookModel.Genre.Science_fiction,
            //        Pages = 152,
            //        Authors = { new AuthorModel { AuthorId = Guid.NewGuid(), FirstName = "Fonda", LastName = "Lee" } } },
    }
}
