namespace Library.UI.Service.API.Dto
{
    public class GetBooksResponse
    {
        public int Count { get; set; }
        
        public string Next { get; set; }

        public string Previous { get; set; }

        public BookDto[] Results { get; set; }
    }
}
