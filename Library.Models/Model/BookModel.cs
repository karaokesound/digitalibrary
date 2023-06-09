﻿using Library.Models.Model;
using Library.Models.Model.many_to_many;
using System;
using System.Collections.Generic;

namespace Library.UI.Model
{
    public class BookModel
    {
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public int Copies { get; set; }

        public string Category { get; set; }

        public int Downloads { get; set; }

        public bool IsRented { get; set; }

        public bool AnyRequest{ get; set; }

        public Guid RequestUserId { get; set; }

        public AuthorModel Author { get; set; }

        public ICollection<BookGradeModel> BookGrade { get; set; }

        public ICollection<CommentModel> Comments { get; set; }

        public ICollection<BookLanguageModel> BookLanguages { get; set; }

        public ICollection<AccountBookModel> AccountBooks { get; set; }

        public enum Genre
        {
            Drama,
            Fiction,
            Adventure_stories,
            Biography,
            Historical_fiction,
            Juvenile_fiction,
            Autobiographical_fiction,
            Comedies,
            Humor,
            Feminist_fiction,
            Horror_tales,
            Poetry,
            Ethics,
            Life,
            Stoics,
            Romances,
            Epic_literature,
            Science_fiction,
            Domestic_fiction,
            Christmas_stories,
            Ghost_stories,
            Love_stories,
            Mysticism,
            Fantasy_literature,
            Calculus,
            Political_fiction,
            Detective_and_mystery_stories,
            Sabotage,
            Bible,
            French_essays,
            Philosophy,
            Gothic_fiction,
            American_drama,
            Communism,
            Socialism,
            Fantasy_fiction,
            Liberty,
            Satire,
            Adultery
        }
    }
}
