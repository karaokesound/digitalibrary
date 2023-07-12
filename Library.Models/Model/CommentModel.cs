using Library.UI.Model;
using System;

namespace Library.Models.Model
{
    public class CommentModel
    {
        public Guid CommentId { get; set; }

        public Guid CommentAuthorId { get; set; }

        public string Text { get; set; }

        public BookModel Book { get; set; }
    }
}
