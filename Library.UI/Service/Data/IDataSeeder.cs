using Library.UI.Service.API.Dto;
using System.Threading.Tasks;

namespace Library.UI.Service.Data
{
    public interface IDataSeeder
    {
        Task SeedDataBase();

        void FillDataBase(BookDto[] bookBaseApi);
    }
}
