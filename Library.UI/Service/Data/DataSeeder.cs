using Library.UI.Model;
using Library.UI.Service.API.Dto;
using Library.UI.Services;

namespace Library.UI.Service.Data
{
    public class DataSeeder
    {
        private readonly IBaseRepository<BookModel> _baseRepository;

        public DataSeeder(IBaseRepository<BookModel> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void FillDatabase(BookDto[] apiBookBase)
        {
            foreach (var apiBook in apiBookBase)
            {
                BookModel book = new BookModel()
                {
                    BookId = apiBook.Id,
                    Title = apiBook.Title,
                };
                _baseRepository.Insert(book);
                _baseRepository.Save();
            }
        }
    }
}
