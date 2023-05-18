using Library.Data;
using Library.UI.Model;
using Library.UI.Service.API;
using Library.UI.Service.API.Dto;
using Library.UI.Services;
using System.Linq;
using System.Windows.Documents;

namespace Library.UI.Service.Data
{
    public class DataSeeder : IDataSeeder
    {
        private readonly IBaseRepository<BookModel> _baseRepository;

        private readonly LibraryDbContext _libraryDbContext;

        private readonly IBookApiService _bookApiService;

        public DataSeeder(IBaseRepository<BookModel> baseRepository, LibraryDbContext libraryDbContext, IBookApiService bookApiService)
        {
            _baseRepository = baseRepository;
            _libraryDbContext = libraryDbContext;
            _bookApiService = bookApiService;
        }

        public async void SeedDataBase()
        {
            if (_libraryDbContext.Books.Any())
            {
                var bookList = _baseRepository.GetAll().ToList();
                foreach (var book in bookList)
                {
                    _baseRepository.Delete(book);
                }
            }

            var bookBaseApi = await _bookApiService.GetBooksAsync();
            FillDataBase(bookBaseApi.Results);
        }

        public void FillDataBase(BookDto[] bookBaseApi)
        {
            foreach (var bookApi in bookBaseApi)
            {
                BookModel book = new BookModel()
                {
                    Title = bookApi.Title,
                };

                var authorApi = bookApi.Authors;
                if (authorApi == null)
                {
                    book.Author = new AuthorModel() { FirstName = "Unknown" };
                }

                foreach (var details in authorApi)
                {
                    string[] fullNameSplit = details.Name.Split(',');
                    book.Author = new AuthorModel()
                    {
                        FirstName = fullNameSplit[1],
                        LastName = fullNameSplit[0]
                    };
                }
                _baseRepository.Insert(book);
                _baseRepository.Save();
            }
        }
    }
}
