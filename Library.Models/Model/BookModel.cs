using System;
using System.Collections.Generic;

namespace Library.UI.Model
{
    public class BookModel
    {

        public enum Genre
        {
            Adventure,
            Classics,
            Crime,
            Fairy_tales,
            Fantasy,
            Historical_fiction,
            Horror,
            Humour_and_satire,
            Literary_fiction,
            Mystery,
            Poetry,
            Plays,
            Romance,
            Science_fiction,
            Short_stories,
            Thrillers,
            War,
            Womens_fiction,
            Young_adult,
        }

        public int BookId { get; set; }

        public string Title { get; set; }

        public ICollection<AuthorModel> Authors { get; set; }

        public Genre Category { get; set; } 

        public int Pages { get; set; }
    }
}
