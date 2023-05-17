using Library.UI.Service.API.Dto;
using Library.UI.Service.Data;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.UI.Service.API
{
    public class ApiBookBase : IApiBookBase
    {
        private readonly HttpClient _http;

        private readonly DataSeeder _dataSeeder;

        public ApiBookBase(DataSeeder dataSeeder)
        {
            _http = new HttpClient()
            {
                BaseAddress = new Uri("https://gutendex.com/books")
            };

            _dataSeeder = dataSeeder;
            GetBooksAsync();
        }

        public async Task<GetBooksResponse> GetBooksAsync()
        {
            var url = "/books";
            var result = new GetBooksResponse();
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

            BookDto[] apiBookBase = result.Results;
            _dataSeeder.FillDatabase(apiBookBase);

            return result;
        }
    }
}
