using Library.Data;
using Library.Models.Model;
using Library.UI.Model;
using Library.UI.Service.API;
using Library.UI.Service.API.Dto;
using Library.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Library.UI.Model.BookModel;

namespace Library.UI.Service.Data
{
    public class DataSeeder : IDataSeeder
    {
        private readonly IBaseRepository<BookModel> _baseRepository;

        private readonly LibraryDbContext _libraryDbContext;

        private readonly IBookApiService _bookApiService;

        private readonly IBaseRepository<LanguageModel> _lngBaseRepository;

        private readonly IBaseRepository<AuthorModel> _authBaseRepository;

        private readonly IDataSorting _dataFiltering;

        public DataSeeder(IBaseRepository<BookModel> baseRepository, LibraryDbContext libraryDbContext,
            IBookApiService bookApiService, IBaseRepository<LanguageModel> langBaseRepository,
            IBaseRepository<AuthorModel> authBaseRepository, IDataSorting dataFiltering)
        {
            _baseRepository = baseRepository;
            _libraryDbContext = libraryDbContext;
            _bookApiService = bookApiService;
            _lngBaseRepository = langBaseRepository;
            _authBaseRepository = authBaseRepository;
            _dataFiltering = dataFiltering;
        }

        public async Task SeedDataBase()
        {
            // removes data from database if exist
            if (await _libraryDbContext.Books.AnyAsync())
            {
                var bookList = _baseRepository.GetAll().ToList();
                foreach (var book in bookList)
                {
                    _baseRepository.Delete(book);
                }
            }

            if (await _libraryDbContext.Languages.AnyAsync())
            {
                var languageList = _lngBaseRepository.GetAll().ToList();
                foreach (var language in languageList)
                {
                    _lngBaseRepository.Delete(language);
                }
            }

            if (await _libraryDbContext.Authors.AnyAsync())
            {
                var authorList = _authBaseRepository.GetAll().ToList();
                foreach (var author in authorList)
                {
                    _authBaseRepository.Delete(author);
                }
            }

            var bookBaseApi = await _bookApiService.GetBooksAsync();
            FillDataBase(bookBaseApi.Results);
        }

        public void FillDataBase(BookDto[] bookBaseApi)
        {
            // Adding enum language list to database
            List<string> enumLanguageList = Enum.GetNames(typeof(LanguageModel.Languages)).ToList();
            List<LanguageModel> languageList = new List<LanguageModel>();

            foreach (string enumLanguage in enumLanguageList)
            {
                languageList.Add(new LanguageModel() { Language = enumLanguage });
            }

            foreach (LanguageModel language in languageList)
            {
                _lngBaseRepository.Insert(language);
                _lngBaseRepository.Save();
            }

            // Inserting new book
            foreach (var bookApi in bookBaseApi)
            {
                BookModel book = new BookModel()
                {
                    Title = bookApi.Title,
                    Downloads = bookApi.Download_Count,
                };


                // Adding Authors first name and last name to Book object
                if (bookApi.Authors == null)
                {
                    book.Author = new AuthorModel() 
                    { 
                        FirstName = "Unknown", 
                        LastName = "Unknown", 
                        BirthYear = 0, 
                        DeathYear = 0 };
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

                var category = categorySplit[counter - 1];
                string[] enumCategories = Enum.GetNames(typeof(Genre));

                for (int i = 0; i < enumCategories.Length; i++)
                {
                    enumCategories[i] = enumCategories[i].Replace('_', ' ');
                }

                foreach (var enumCategory in enumCategories)
                {
                    if (category == enumCategory)
                    {
                        book.Category = category;
                        break;
                    }
                    book.Category = "Other";
                }


                // Adding Language to Book object. The Language Object is a collection.
                List<LanguageModel> databaseLanguageList = _lngBaseRepository.GetAll().ToList();
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
