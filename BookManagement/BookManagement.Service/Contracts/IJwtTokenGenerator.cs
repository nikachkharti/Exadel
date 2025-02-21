using BookManagement.Models.Entities;

namespace BookManagement.Service.Contracts
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
