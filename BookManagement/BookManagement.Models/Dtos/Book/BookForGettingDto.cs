namespace BookManagement.Models.Dtos.Book
{
    public class BookForGettingDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationYear { get; set; }
        public int ViewCount { get; set; }
        public int Age { get; set; }
        public double PopularityScore { get; set; }
    }
}
