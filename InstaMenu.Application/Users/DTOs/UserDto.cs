namespace InstaMenu.Application.Users.DTOs
{
    public record UserDto
    {
        public string UserId { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }

        public bool Deleted { get; init; }
        public string CreatedById { get; init; }
        public DateTime CreationDate { get; init; }
        public string? ModifiedById { get; init; }
        public DateTime? ModificationDate { get; init; }
    }



}
