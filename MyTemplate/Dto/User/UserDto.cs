namespace Web.Dto.User
{
    public class UserDto
    {
        public long UserId { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}