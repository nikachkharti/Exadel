using BookManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Repository.Data.EF
{
    public static class ContextHelper
    {
        public static void ConfigureBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                //Id
                entity.HasKey(b => b.Id);
                entity
                    .Property(b => b.Id)
                    .IsRequired();

                //Title
                modelBuilder.Entity<Book>()
                    .HasIndex(b => b.Title)
                    .IsUnique();
                entity
                    .Property(b => b.Title)
                    .HasMaxLength(100)
                    .IsRequired();

                //PublicationYear
                modelBuilder.Entity<Book>()
                    .Property(b => b.PublicationYear)
                    .HasColumnType("DATE");

                //ViewCount
                entity.Property(b => b.ViewCount)
                    .IsRequired();


                //AuthorName
                entity
                    .Property(a => a.AuthorName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.Parse("EF924032-43A1-4531-AD96-5EE190790AF8"),
                    Title = "Three Musketers",
                    AuthorName = "Alexander Dumas",
                    PublicationYear = DateTime.Parse("1844-07-10"),
                    ViewCount = 5
                },
                new Book()
                {
                    Id = Guid.Parse("B6A80EDC-D005-47C6-8241-619109DA1504"),
                    Title = "The Brothers Karamazov",
                    AuthorName = "Fiodor Dostoevsky",
                    PublicationYear = DateTime.Parse("1880-11-01"),
                    ViewCount = 11
                },
                new Book()
                {
                    Id = Guid.Parse("522F3F16-5AE3-42EA-9C19-90995B097805"),
                    Title = "Don Quixote",
                    AuthorName = "Miguel de Cervantes",
                    PublicationYear = DateTime.Parse("1605-01-16"),
                    ViewCount = 9
                }
            );

        }
    }
}
