﻿namespace InstaMenu.Application.Users.DTOs
{
    public sealed record UpdateUserDto
    {
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? Name { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Password { get; set; }

    }

}
