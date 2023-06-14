using Library.Models.Model;
using Library.UI.Services;
using System;
using System.Collections.Generic;

namespace Library.UI.Service
{
    public interface IAccountBookRepository : IBaseRepository<AccountBookModel>
    {
        void DeleteUserBook(Guid accountId, Guid bookId);

        int ReturnAccountBookQuantity(Guid accountId, Guid bookId);

        AccountBookModel GetUserBookByID(Guid accountId, Guid bookId);

        List<AccountBookModel> GetAllUserBooksByID(Guid accountId);
    }
}
