using BookManagement.Service.Exceptions.Base.Exceptions;

namespace BookManagement.Service.Exceptions
{
    public class BookAlreadyExistsException : BadRequestException
    {
        public BookAlreadyExistsException(string bookId) : base($"Book with id {bookId} already exists")
        {
        }
    }
}
