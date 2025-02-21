using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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

        [Required]
        public DateTime PublicationYear { get; set; }

        [Required]
        public int ViewCount { get; set; } = 0;

        public override bool Equals(object obj) => new BookForCreatingDtoEquilityComparer().Equals(this, obj as BookForCreatingDto);
        public override int GetHashCode() => new BookForCreatingDtoEquilityComparer().GetHashCode(this);
    }

    public class BookForCreatingDtoEquilityComparer : IEqualityComparer<BookForCreatingDto>
    {
        public bool Equals(BookForCreatingDto x, BookForCreatingDto y) => x.Title.ToLower().Trim() == y.Title.ToLower().Trim();
        public int GetHashCode([DisallowNull] BookForCreatingDto obj) => obj.Title.Length;
    }
}
