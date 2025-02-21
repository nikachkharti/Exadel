using BookManagement.Repository.Contracts;

namespace BookManagement.Service.Contracts
{
    public interface IUnitOfWork
    {
        public IBookRepository BookRepository { get; }
        public IBookService BookService { get; }
        Task<int> Save();
    }
}
