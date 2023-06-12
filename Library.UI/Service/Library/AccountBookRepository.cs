﻿using Library.Models.Model;
using Library.UI.Services;
using System;
using System.Linq;

namespace Library.UI.Service.Library
{
    public class AccountBookRepository : BaseRepository<AccountBookModel>, IAccountBookRepository
    {
        public void DeleteUserBook(Guid accountId, Guid bookId)
        {
            var books = _dbSet.ToList();

            var matchingBooks = books.Where(b => b.AccountId == accountId).Where(b => b.BookId == bookId).ToList();

            foreach (var book in matchingBooks)
            {
                _dbSet.Remove(book);
            }
        }

        public virtual int ReturnBookQuantity(Guid accountId, Guid bookId)
        {
            var books = _dbSet.ToList();

            var rentedBook = books.FirstOrDefault(a => a.AccountId == accountId && a.BookId == bookId);

            var rentedBookQuantity = rentedBook != null ? rentedBook.Quantity : 0;

            return rentedBookQuantity;
        }

        public AccountBookModel GetUserBooks(Guid accountId, Guid bookId)
        {
            var books = _dbSet.ToList();

            var searchedBook = books.FirstOrDefault(a => a.AccountId == accountId && a.BookId == bookId);
            return searchedBook;
        }
    }
}
