using BookManagement.Models.Entities;

namespace BookManagement.Repository.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>, IUpdatable<Book>
    {
    }
}
