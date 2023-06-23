using Library.Data;
using Library.Models.Model;
using Library.UI.Model;
using Library.UI.Service.API;
using Library.UI.Service.API.Dto;
using Library.UI.Services;
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

        private readonly IBaseRepository<GradeModel> _gradeBaseRepository;

        public DataSeeder(IBaseRepository<BookModel> bookBaseRepository, LibraryDbContext libraryDbContext,
            IBookApiService bookApiService, IBaseRepository<LanguageModel> langBaseRepository,
            IBaseRepository<AuthorModel> authBaseRepository, IDataSorting dataFiltering, IBaseRepository<GradeModel> gradeBaseRepository)
        {
            _bookBaseRepository = bookBaseRepository;
            _libraryDbContext = libraryDbContext;
            _bookApiService = bookApiService;
            _lngBaseRepository = langBaseRepository;
            _authBaseRepository = authBaseRepository;
            _dataFiltering = dataFiltering;
            _gradeBaseRepository = gradeBaseRepository;
        }

        public async Task SeedDataBase()
        {
            if (_libraryDbContext.Books.Any())
            {
                return;
            }

            var bookBaseApi = await _bookApiService.GetBooksAsync();
            FillDataBase(bookBaseApi);
        }

        public void FillDataBase(List<BookDto> bookBaseApi)
        {
            // Adding Languages enum to database
            List<string> languagesEnumList = Enum.GetNames(typeof(LanguageModel.Languages)).ToList();
            List<LanguageModel> languageList = new List<LanguageModel>();

            foreach (string languageEnum in languagesEnumList)
            {
                languageList.Add(new LanguageModel() { Language = languageEnum });
            }

            foreach (LanguageModel language in languageList)
            {
                _lngBaseRepository.Insert(language);
                _lngBaseRepository.Save();
            }

            // Adding Grades enum to database
            List<int> gradesEnumValues = Enum.GetValues(typeof(GradeModel.Grades))
                .Cast<int>()
                .ToList();
            List<GradeModel> gradeList = new List<GradeModel>();

            foreach (var gradeEnum in gradesEnumValues)
            {
                gradeList.Add(new GradeModel() { Grade = gradeEnum });
            }

            foreach (GradeModel grade in gradeList)
            {
                _gradeBaseRepository.Insert(grade);
                _gradeBaseRepository.Save();
            }

            // Inserting New Book
            foreach (var bookApi in bookBaseApi)
            {
                BookModel book = new BookModel()
                {
                    Title = bookApi.Title,
                    Downloads = bookApi.Download_Count,
                    IsRented = false,
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
                string[] enumCategories = Enum.GetNames(typeof(Genre)).ToArray();
                for (int i = 0; i < enumCategories.Length; i++)
                {
                    enumCategories[i] = enumCategories[i].Replace('_', ' ');
                }

                if (bookApi.Subjects.Length > 0)
                {
                    string[] categorySplit = bookApi.Subjects[0].TrimStart().Split(new string[] { "-- " }, StringSplitOptions.RemoveEmptyEntries);
                    int counter = categorySplit.Count();

                    if (counter > 0)
                    {
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
                    }
                }
                else
                {
                    book.Category = "Other";
                }

                // Adding Language Object (The Language Object is a collection)
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

                List<BookLanguageModel> matchedBookLanguages = new List<BookLanguageModel>();

                foreach (var language in matchedLanguages)
                {
                    var matched = new BookLanguageModel()
                    {
                        BookId = book.BookId,
                        LanguageId = language.LanguageId
                    };
                    matchedBookLanguages.Add(matched);
                }

                book.BookLanguages = matchedBookLanguages;

                // Declaration of a random number of copies of a given book
                Random copiesQuantity = new Random();

                if (bookApi.Download_Count >= 20000) book.Copies = copiesQuantity.Next(15, 25);
                else if (bookApi.Download_Count < 20000 && bookApi.Download_Count >= 10000) book.Copies = copiesQuantity.Next(10, 15);
                else if (bookApi.Download_Count < 10000 && bookApi.Download_Count >= 5000) book.Copies = copiesQuantity.Next(6, 10);
                else if (bookApi.Download_Count < 5000) book.Copies = copiesQuantity.Next(0, 5);

                _bookBaseRepository.Insert(book);
                _bookBaseRepository.Save();
            }
        }
    }
}
