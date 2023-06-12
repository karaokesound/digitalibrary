using Library.Models.Model;
using Library.UI.Model;
using Library.UI.Services;
using System;
using System.Collections.Generic;

namespace Library.UI.Service
{
    public interface IAccountBookRepository : IBaseRepository<AccountBookModel>
    {
        void DeleteUserBook(Guid accountId, Guid bookId);

        int ReturnBookQuantity(Guid accountId, Guid bookId);

        AccountBookModel GetUserBooks(Guid accountId, Guid bookId);
    }
}
