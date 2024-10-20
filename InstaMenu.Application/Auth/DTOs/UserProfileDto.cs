namespace InstaMenu.Application.Auth.DTOs
{
    public record UserProfileDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
