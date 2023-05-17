namespace Library.UI.Service.API.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public AuthorDto authors { get; set; }

        public string Translators { get; set; }

        public SubjectDto Subjects { get; set; }

        public string BookShelves { get; set; }

        public LanguageDto Languages { get; set; }

        public bool Copyright { get; set; }

        public string Media_Type { get; set; }

        public string Formats { get; set; }

        public int Download_Count { get; set; }
    }
}
