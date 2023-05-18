using Library.UI.Service.API.Dto;
using Newtonsoft.Json;
using System;
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

        public async Task<GetBooksResponse> GetBooksAsync()
        {
            var result = new GetBooksResponse();
            for (int page = 1; page < 10; page++)
            {
                var url = ($"/books/page?={page}");
               
                var response = await _http.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<GetBooksResponse>(stringResponse);
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            return result;
        }
    }
}
