using System.ComponentModel.DataAnnotations;

namespace InstaMenu.Application.Auth.DTOs
{
    public class ChangePasswordDto
    {
        public string? StudentId { get; init; }

        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword), ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }

    }
}
