using BookManagement.Models.Dtos;

namespace BookManagement.Service.Contracts
{
    public interface IBookService
    {
        Task<List<string>> GetPopularBooks(int pageNumber = 1, int pageSize = 10);
        Task<BookForGettingDto> GetBookDetails(Guid bookId);
        Task<Guid> AddSingleBook(BookForCreatingDto bookForCreatingDto);
        Task<IEnumerable<Guid>> AddMultipleBooks(HashSet<BookForCreatingDto> booksForCreatingDto);
        Task<Guid> UpdateSingleBook(BookForUpdatingDto bookForUpdatingDto);
        Task<Guid> DeleteSingleBook(Guid bookId);
        Task<IEnumerable<Guid>> DeleteMultipleBooks(HashSet<Guid> bookIds);
    }
}
