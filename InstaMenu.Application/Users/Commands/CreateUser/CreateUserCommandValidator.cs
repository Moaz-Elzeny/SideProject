using FluentValidation;

namespace InstaMenu.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        //private readonly IApplicationDbContext _context;
        //public CreateUserCommandValidator(IApplicationDbContext context)
        //{
        //    _context = context;

        //    RuleFor(x => x.UserName)
        //         .NotEmpty().WithMessage("Username is required.")
        //         .MustAsync(BeUniqueUserName).WithMessage("Username is already taken.");

        //    RuleFor(x => x.Email)
        //        .NotEmpty().WithMessage("Email is required.")
        //        .EmailAddress().WithMessage("Invalid email format.")
        //        .MustAsync(BeUniqueEmail).WithMessage("Email is already taken.");

        //    RuleFor(x => x.Password)
        //        .NotEmpty().WithMessage("Password is required.")
        //        .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        //}
        //private async Task<bool> BeUniqueUserName(string userName, CancellationToken cancellationToken)
        //{
        //    var existingUser = await _context.AppUsers.IgnoreQueryFilters().FirstOrDefaultAsync(a => a.UserName == userName);
        //    return existingUser == null;
        //}

        //private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        //{
        //    var existingUser = await _context.AppUsers.IgnoreQueryFilters().FirstOrDefaultAsync(a => a.Email == email);
        //    return existingUser == null;
        //}
        //private async Task<bool> BeUniqueNationalIdNumber(string NationalIdNumber, CancellationToken cancellationToken)
        //{
        //    var existingUser = await _context.AppUsers.FirstOrDefaultAsync(u => u.NationalIdNumber == NationalIdNumber && u.NationalIdNumber != null);
        //    return existingUser == null;
        //}
    }
}
