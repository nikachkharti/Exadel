namespace BookManagement.Models.Dtos.Identity
{
    public class LoginRequestDto
    {
        /// <summary>
        /// Email will be used as username
        /// </summary>
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
