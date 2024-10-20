using FluentValidation;

namespace InstaMenu.Application.Users.Commands.EditUser
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {

        public EditUserCommandValidator()
        {

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.");

           
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");

        }




    }
}
