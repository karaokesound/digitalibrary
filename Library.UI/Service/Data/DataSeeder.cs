using Library.Data;
using Library.Models.Model;
using Library.UI.Model;
using Library.UI.Service.API;
using Library.UI.Service.API.Dto;
using Library.UI.Services;
using System;
using System.Collections.Generic;
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


                // Adding Author first name and last name to Book object
                var authorApi = bookApi.Authors;

                if (authorApi == null)
                {
                    book.Author = new AuthorModel() { FirstName = "Unknown", LastName = "Unknown",
                        BirthYear = 0, DeathYear = 0};
                    
                }

                foreach (var authorDetails in authorApi)
                {
                    string[] nameSplit = authorDetails.Name.Split(',');
                    book.Author = new AuthorModel()
                    {
                        FirstName = nameSplit[1],
                        LastName = nameSplit[0],
                        BirthYear = (int)authorDetails.Birth_Year,
                        DeathYear = (int)authorDetails.Death_Year,
                    };
                }

                // Adding Category to Book object
                var categoryApi = bookApi.Subjects[0];
                string[] categorySplit = categoryApi.Split(new string[] { "--" }, StringSplitOptions.RemoveEmptyEntries);
                int counter = categorySplit.Count();
                book.Category = categorySplit[counter - 1];

                // Adding Language to Book object
                var languagesApi = bookApi.Languages;
                List<LanguageModel> languageList = new List<LanguageModel>();

                foreach (var language in languagesApi)
                {
                    languageList.Add(new LanguageModel()
                    {
                        Language = language
                    });
                }
                book.Languages = languageList;

                _baseRepository.Insert(book);
                _baseRepository.Save();
            }
        }
    }
}
