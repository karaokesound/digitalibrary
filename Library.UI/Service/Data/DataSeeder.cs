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
        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly LibraryDbContext _libraryDbContext;

        private readonly IBookApiService _bookApiService;

        private readonly IBaseRepository<LanguageModel> _lngBaseRepository;

        private readonly IBaseRepository<AuthorModel> _authBaseRepository;

        private readonly IDataSorting _dataFiltering;

        public DataSeeder(IBaseRepository<BookModel> bookBaseRepository, LibraryDbContext libraryDbContext,
            IBookApiService bookApiService, IBaseRepository<LanguageModel> langBaseRepository,
            IBaseRepository<AuthorModel> authBaseRepository, IDataSorting dataFiltering)
        {
            _bookBaseRepository = bookBaseRepository;
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
                var bookList = _bookBaseRepository.GetAll().ToList();
                foreach (var book in bookList)
                {
                    _bookBaseRepository.Delete(book);

                }
                var languageList = _lngBaseRepository.GetAll().ToList();
                foreach (var language in languageList)
                {
                    _lngBaseRepository.Delete(language);
                }
                var authorList = _authBaseRepository.GetAll().ToList();
                foreach (var author in authorList)
                {
                    _authBaseRepository.Delete(author);
                }
                _bookBaseRepository.Save();
                _lngBaseRepository.Save();
                _authBaseRepository.Save();
            }

            var bookBaseApi = await _bookApiService.GetBooksAsync();
            FillDataBase(bookBaseApi);
        }

        public void FillDataBase(List<BookDto> bookBaseApi)
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


            // Inserting New Book
            foreach (var bookApi in bookBaseApi)
            {
                BookModel book = new BookModel()
                {
                    Title = bookApi.Title,
                    Downloads = bookApi.Download_Count,
                };


                // Adding Author object
                if (bookApi.Authors.Length == 0) continue;

                foreach (var authorDetails in bookApi.Authors)
                {
                    if (authorDetails.Name == null) continue;
                    if (authorDetails.Birth_Year == null) authorDetails.Birth_Year = 0;
                    if (authorDetails.Death_Year == null) authorDetails.Death_Year = 0;

                    string[] nameSplit = authorDetails.Name.Split(", ");
                    
                    if (nameSplit.Length == 1)
                    {
                        book.Author = new AuthorModel()
                        {
                            FirstName = nameSplit[0],
                            LastName = " ",
                            BirthYear = (int)authorDetails.Birth_Year,
                            DeathYear = (int)authorDetails.Death_Year,
                        };
                    }
                    else
                    {
                        book.Author = new AuthorModel()
                        {
                            FirstName = nameSplit[1],
                            LastName = nameSplit[0],
                            BirthYear = (int)authorDetails.Birth_Year,
                            DeathYear = (int)authorDetails.Death_Year,
                        };
                    }
                }


                // Adding Category
                string[] enumCategories = Enum.GetNames(typeof(Genre));
                for (int i = 0; i < enumCategories.Length; i++)
                {
                    enumCategories[i] = enumCategories[i].Replace('_', ' ');
                }

                string[] categorySplit = bookApi.Subjects[0].TrimStart().Split(new string[] { "-- " }, StringSplitOptions.RemoveEmptyEntries);
                int counter = categorySplit.Count();
                var bookCategory = categorySplit[counter - 1];

                foreach (var enumCategory in enumCategories)
                {
                    if (bookCategory == enumCategory)
                    {
                        book.Category = bookCategory;
                        break;
                    }
                    book.Category = "Other";
                }


                // Adding Language Object (Language Object is a collection)
                List<LanguageModel> databaseLanguageList = _lngBaseRepository.GetAll().ToList();
                List<string> bookLanguageList = bookApi.Languages.ToList();

                List<LanguageModel> matchedLanguages = new List<LanguageModel>();

                foreach (var bookLanguage in bookLanguageList)
                {
                    var matchingLanguage = databaseLanguageList.FirstOrDefault(language => language.Language == bookLanguage);
                    if (matchingLanguage != null)
                    {
                        matchedLanguages.Add(matchingLanguage);
                    }
                }

                book.Languages = matchedLanguages;

                _bookBaseRepository.Insert(book);
                _bookBaseRepository.Save();
            }
        }
    }
}
