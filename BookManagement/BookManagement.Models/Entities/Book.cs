namespace BookManagement.Models.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationYear { get; set; }
        public int ViewCount { get; set; } = 0;
    }
}
