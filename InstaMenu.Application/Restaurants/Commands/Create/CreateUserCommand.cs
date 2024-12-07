using InstaMenu.Application.Common.Models;
using InstaMenu.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace InstaMenu.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ResultDto<object>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CurrentUserId { get; set; }
        
        //public IFormFile? ProfilePicture { get; set; }
        
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultDto<object>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IHostingEnvironment _environment;

            public CreateUserCommandHandler(UserManager<AppUser> userManager, IHostingEnvironment environment)
            {
                _userManager = userManager;
                _environment = environment;
            }

            public async Task<ResultDto<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                //var dsd = Encrypt(request.Password);
                //var dsdd = Decrypt(dsd);

                var user = new AppUser
                {
                    Name = request.Name,
                    UserName = request.UserName,
                    Email = request.Email,
                    CreatedById = "InstaMenuAdmin",
                    CreationDate = DateTime.Now,
                    PhoneNumber = request.PhoneNumber,
                };
                //if (request.ProfilePicture != null) { user.ProfilePicture = await FileHelper.SaveImageAsync(request.ProfilePicture, _environment); }

                var result = await _userManager.CreateAsync(user, request.Password);

                return ResultDto<object>.Success(new
                {
                    Message = "Created Successfully ✔️",
                    Result = new
                    {
                        user.Id
                    }
                });


                //if (result.Succeeded)
                //{
                //    await _userManager.AddToRoleAsync(user, request.Name.ToString());

                //    var jwtSecurityToken = await CreateJwtToken(user);
                //    var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                //    var userId = user.Id;
                //    var userToken = new UserTokenDto { UserId = userId, Token = token };

                //    return ResultDto<UserTokenDto>.Success(userToken);
                //}
                //else
                //{
                //    return ResultDto<UserTokenDto>.Failure(result.Errors.FirstOrDefault().Description);
                //}
            }
            
        //    private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
        //    {
        //        var userClaims = await _userManager.GetClaimsAsync(user);
        //        var roles = await _userManager.GetRolesAsync(user);
        //        var roleClaims = new List<Claim>();

        //        foreach (var role in roles)
        //            roleClaims.Add(new Claim(ClaimTypes.Role, role));

        //        var claims = new[]
        //        {
        //    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //    new Claim("uid", user.Id)
        //}
        //        .Union(userClaims)
        //        .Union(roleClaims);

        //        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("lG0rDWELYD0jPtoLNlc/sMVREJMh8laXd5bvVEZzUeg="));
        //        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        //        var jwtSecurityToken = new JwtSecurityToken(
        //            issuer: "SecureApi",
        //            audience: "SecureApiUser",
        //            claims: claims,
        //            expires: DateTime.Now.AddDays(30),
        //            signingCredentials: signingCredentials);

        //        return jwtSecurityToken;
        //    }

        }
    }
}
