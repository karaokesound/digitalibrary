using Library.UI.Service.API.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.UI.Service.API
{
    public class BookApiService : IBookApiService
    {
        private readonly HttpClient _http;

        public BookApiService()
        {
            _http = new HttpClient()
            {
                BaseAddress = new Uri("https://gutendex.com/")
            };
        }

        public async Task<List<BookDto>> GetBooksAsync()
        {
            var books = new List<BookDto>();
            var url = "/books/?page=";

            for (int pageNumber = 1; pageNumber <= 40; pageNumber++)
            {
                var response = await _http.GetAsync(url + pageNumber);

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var pageResult = JsonConvert.DeserializeObject<GetBooksResponse>(stringResponse);

                    if (pageResult.Results.Length > 0)
                    {
                        books.AddRange(pageResult.Results);
                        pageNumber++;

                        if (string.IsNullOrEmpty(pageResult.Next))
                        {
                            // Brak więcej wyników, opuść pętlę
                            break;
                        }
                    }
                    else
                    {
                        // Brak więcej wyników, opuść pętlę
                        break;
                    }
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }

            return books;
        }
    }
}
