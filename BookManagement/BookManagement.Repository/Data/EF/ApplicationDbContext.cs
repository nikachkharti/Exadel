using BookManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Repository.Data.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureBooks();
            modelBuilder.SeedBooks();
        }
    }
}
