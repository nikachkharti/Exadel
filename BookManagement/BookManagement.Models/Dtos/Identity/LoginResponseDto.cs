namespace BookManagement.Models.Dtos.Identity
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
