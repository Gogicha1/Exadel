namespace Exadel.Requests
{
    public class BookRequestModel
    {
        public string Title { get; set; }
        public string? Author { get; set; }
        public int PublicationYear { get; set; }
        public int Views { get; set; }
    }
}
