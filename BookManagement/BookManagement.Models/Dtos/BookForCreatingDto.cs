using System.ComponentModel.DataAnnotations;

namespace BookManagement.Models.Dtos
{
    public class BookForCreatingDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string AuthorName { get; set; }
        public DateTime PublicationYear { get; set; }

        [Required]
        public int ViewCount { get; set; } = 0;
    }
}
