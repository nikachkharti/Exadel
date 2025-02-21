using BookManagement.Models.Entities;
using BookManagement.Repository.Contracts;
using BookManagement.Repository.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Repository.Implementations
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Book entity)
        {
            var entityFromDb = await _context.Books.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb is not null)
            {
                entityFromDb.Title = entity.Title;
                entityFromDb.PublicationYear = entity.PublicationYear;
                entityFromDb.ViewCount = entity.ViewCount;
                entityFromDb.AuthorName = entity.AuthorName;
            }
        }

        public async Task IncreaseView(Guid bookId)
        {
            var entityFromDb = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookId);

            if (entityFromDb is not null)
            {
                entityFromDb.ViewCount += 1;
            }
        }
    }
}
