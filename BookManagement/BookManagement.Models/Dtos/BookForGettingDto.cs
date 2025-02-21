namespace BookManagement.Models.Dtos
{
    public class BookForGettingDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationYear { get; set; }
        public int ViewCount { get; set; }
    }
}
