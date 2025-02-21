﻿using System.ComponentModel.DataAnnotations;

namespace BookManagement.Models.Dtos.Book
{
    public class BookForUpdatingDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string AuthorName { get; set; }

        [Required]
        public DateTime PublicationYear { get; set; }

        [Required]
        public int ViewCount { get; set; }
    }
}
