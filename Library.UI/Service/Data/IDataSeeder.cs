using Library.UI.Service.API.Dto;

namespace Library.UI.Service.Data
{
    public interface IDataSeeder
    {
        void SeedDataBase();

        void FillDataBase(BookDto[] bookBaseApi);
    }
}
