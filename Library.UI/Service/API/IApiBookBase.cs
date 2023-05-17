using Library.UI.Service.API.Dto;
using System.Threading.Tasks;

namespace Library.UI.Service.API
{
    public interface IApiBookBase
    {
        Task<GetBooksResponse> GetBooksAsync();
    }
}
