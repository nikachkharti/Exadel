using BookManagement.Service.Exceptions.Base.Exceptions;

namespace BookManagement.Service.Exceptions
{
    public class RegistrationFailureException : BadRequestException
    {
        public RegistrationFailureException(string message) : base(message)
        {
        }
    }
}
