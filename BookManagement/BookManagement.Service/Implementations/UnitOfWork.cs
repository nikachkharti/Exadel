using BookManagement.Repository.Contracts;
using BookManagement.Repository.Data.EF;
using BookManagement.Repository.Implementations;
using BookManagement.Service.Contracts;

namespace BookManagement.Service.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBookRepository BookRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            BookRepository = new BookRepository(context);
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}
