using System;
using System.Collections.Generic;

namespace Library.Models.Model
{
    public class LanguageModel
    {
        public Guid LanguageId { get; set; }

        public string Language { get; set; }

        public ICollection<BookLanguageModel> BookLanguages { get; set; }

        public enum Languages
        {
            en,
            tl,
            de,
            es,
            pl   
        }
    }
}
