using Library.UI.Service.API.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.UI.Service.Data
{
    public interface IDataSeeder
    {
        Task SeedDataBase();

        void FillDataBase(List<BookDto> bookBaseApi);
    }
}
