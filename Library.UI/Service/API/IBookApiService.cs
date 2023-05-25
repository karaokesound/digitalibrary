using Library.UI.Service.API.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.UI.Service.API
{
    public interface IBookApiService
    {
        Task<List<BookDto>> GetBooksAsync();
    }
}
