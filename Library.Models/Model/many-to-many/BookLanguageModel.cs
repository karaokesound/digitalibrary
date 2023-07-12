using Library.UI.Model;
using System;

namespace Library.Models.Model
{
    public class BookLanguageModel
    {
        public Guid BookId { get; set; }

        public BookModel Book { get; set; }

        public Guid LanguageId { get; set; }

        public LanguageModel Language { get; set; }
    }
}
