
using FluentValidation;
using global::InstaMenu.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;


namespace InstaMenu.Application.Users.Commands.CreateUser
{


    namespace InstaMenu.Application.Users.Commands.CreateUser
    {
        public class NoSyncCreateUserCommandValidator : AbstractValidator<CreateUserCommand>
        {
            private readonly UserManager<AppUser> _userManager;

            public NoSyncCreateUserCommandValidator(UserManager<AppUser> userManager)
            {
                _userManager = userManager;

                RuleFor(x => x.UserName)
                     .NotEmpty().WithMessage("Username is required.")
                     .Must(BeUniqueUserName).WithMessage("Username is already taken.");

                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Invalid email format.")
                    .Must(BeUniqueEmail).WithMessage("Email is already taken.");

                RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("Password is required.")
                    .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            }

            private bool BeUniqueUserName(string userName)
            {
                var existingUser = _userManager.FindByNameAsync(userName).Result;
                return existingUser == null;
            }

            private bool BeUniqueEmail(string email)
            {
                var existingUser = _userManager.FindByEmailAsync(email).Result;
                return existingUser == null;
            }
        }
    }

}
