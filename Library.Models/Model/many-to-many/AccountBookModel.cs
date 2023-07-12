using Library.UI.Model;
using System;

namespace Library.Models.Model
{
    public class AccountBookModel
    {
        public Guid AccountId { get; set; }

        public AccountModel Account { get; set; }

        public Guid BookId { get; set; }

        public BookModel Book { get; set; }

        public int Quantity { get; set; }
    }
}
