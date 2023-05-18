namespace Library.UI.Service.API.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public AuthorDto[] Authors { get; set; }

        //public AuthorDto[] Translators { get; set; }

        public string[] Subjects { get; set; }

        //public string[] BookShelves { get; set; }

        public string[] Languages { get; set; }

        public bool Copyright { get; set; }

        //public string Media_Type { get; set; }

        //public FormatDto Formats { get; set; }

        public int Download_Count { get; set; }
    }
}
