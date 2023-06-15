using Library.UI.Model;
using System;

namespace Library.Models.Model.many_to_many
{
    public class BookGradeModel
    {
        public Guid BookId { get; set; }

        public BookModel Book { get; set; }

        public Guid GradeId { get; set; }

        public GradeModel Grade { get; set; }

        public Guid GradeAuthorId { get; set; }
    }
}
