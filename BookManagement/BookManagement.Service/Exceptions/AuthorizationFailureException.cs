using BookManagement.Service.Exceptions.Base.Exceptions;

namespace BookManagement.Service.Exceptions
{
    public class AuthorizationFailureException : BadRequestException
    {
        public AuthorizationFailureException(string user) : base($"Error while authorization process for user {user}")
        {
        }
    }
}
