using BookManagement.Service.Exceptions.Base.Exceptions;

namespace BookManagement.Service.Exceptions
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(string bookId) : base($"Book with id {bookId} not found")
        {
        }
    }
}
