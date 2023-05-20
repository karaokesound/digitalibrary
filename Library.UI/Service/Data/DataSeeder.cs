using Library.Data;
using Library.Models.Model;
using Library.UI.Model;
using Library.UI.Service.API;
using Library.UI.Service.API.Dto;
using Library.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using static Library.UI.Model.BookModel;

namespace Library.UI.Service.Data
{
    public class DataSeeder : IDataSeeder
    {
        private readonly IBaseRepository<BookModel> _baseRepository;

        private readonly LibraryDbContext _libraryDbContext;

        private readonly IBookApiService _bookApiService;
        private readonly IBaseRepository<LanguageModel> _langbaseRepository;

        public DataSeeder(IBaseRepository<BookModel> baseRepository, LibraryDbContext libraryDbContext, 
            IBookApiService bookApiService, IBaseRepository<LanguageModel> langbaseRepository)
        {
            _baseRepository = baseRepository;
            _libraryDbContext = libraryDbContext;
            _bookApiService = bookApiService;
            _langbaseRepository = langbaseRepository;
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

            if (_libraryDbContext.Languages.Any())
            {
                var languageList = _langbaseRepository.GetAll().ToList();
                foreach (var language in languageList)
                {
                    _langbaseRepository.Delete(language);
                }
            }

            var bookBaseApi = await _bookApiService.GetBooksAsync();
            FillDataBase(bookBaseApi.Results);
        }

        public void FillDataBase(BookDto[] bookBaseApi)
        {
            // Adding enum language list to database.
            List<string> enumLanguageList = Enum.GetNames(typeof(LanguageModel.Languages)).ToList();
            List<LanguageModel> languageList = new List<LanguageModel>();
            foreach (string language in enumLanguageList)
            {
                languageList.Add(new LanguageModel() { Language = language });
            }

            foreach (LanguageModel languageModel in languageList)
            {
                _langbaseRepository.Insert(languageModel);
                _langbaseRepository.Save();
            }

            // Inserting new book.
            foreach (var bookApi in bookBaseApi)
            {
                BookModel book = new BookModel()
                {
                    Title = bookApi.Title,
                    Downloads = bookApi.Download_Count,
                };


                // Adding Author first name and last name to Book object
                if (bookApi.Authors == null)
                {
                    book.Author = new AuthorModel() { FirstName = "Unknown", LastName = "Unknown", BirthYear = 0, DeathYear = 0 };
                }

                foreach (var authorDetails in bookApi.Authors)
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
                string[] categorySplit = bookApi.Subjects[0].TrimStart().Split(new string[] { "-- " }, StringSplitOptions.RemoveEmptyEntries);
                int counter = categorySplit.Count();
                var comparedCategory = categorySplit[counter - 1];
                string[] categories = Enum.GetNames(typeof(Genre));
                for (int i = 0; i < categories.Length; i++)
                {
                    categories[i] = categories[i].Replace('_', ' ');
                }

                foreach (var category in categories)
                {
                    if (comparedCategory == category)
                    {
                        book.Category = category;
                        break;
                    }
                    book.Category = "Other";
                }


                // Adding Language to Book object. The Language Object is a collection.
                List<LanguageModel> databaseLanguageList = _langbaseRepository.GetAll().ToList();
                List<string> bookLanguageList = bookApi.Languages.ToList();
                List<LanguageModel> matchedLanguages = new List<LanguageModel>();

                foreach (var bookLanguage in bookLanguageList)
                {
                    var matchingLanguage = databaseLanguageList.FirstOrDefault(lang => lang.Language == bookLanguage);
                    if (matchingLanguage != null)
                    {
                        matchedLanguages.Add(matchingLanguage);
                    }
                }

                book.Languages = matchedLanguages;

                _baseRepository.Insert(book);
                _baseRepository.Save();
            }
        }
    }
}
