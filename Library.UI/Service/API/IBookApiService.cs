using Library.UI.Service.API.Dto;
using System.Threading.Tasks;

namespace Library.UI.Service.API
{
    public interface IBookApiService
    {
        Task<GetBooksResponse> GetBooksAsync();
    }
}
