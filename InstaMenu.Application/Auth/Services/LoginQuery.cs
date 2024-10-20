//using InstaMenu.Application.Auth.DTOs;
//using InstaMenu.Application.Common.Models;
//using InstaMenu.Domain.Entities.Auth;
//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.IdentityModel.Tokens;
//using SendGrid.Helpers.Errors.Model;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;

//namespace InstaMenu.Application.Auth.Services
//{
//    public record LoginQuery : IRequest<ResultDto<LoginDto>>
//    {
//        public string UserName { get; init; }
//        public string Password { get; init; }

//    }

//    public class LoginQueryHandler : IRequestHandler<LoginQuery, ResultDto<LoginDto>>
//    {
//        private readonly UserManager<AppUser> _userManager;
//        private readonly IApplicationDbContext _context;
//        private readonly IMediator _mediator;

//        public LoginQueryHandler(UserManager<AppUser> userManager, IApplicationDbContext context, IMediator mediator)
//        {
//            _userManager = userManager;
//            _context = context;
//            _mediator = mediator;
//        }

//        public async Task<ResultDto<LoginDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
//        {
//            var user = await _userManager.FindByNameAsync(request.UserName) ?? throw new NotFoundException("User Not Found!");
//            //var password = Decrypt(user.PasswordHash);

//            var password = await _userManager.CheckPasswordAsync(user, request.Password);


//            if (password)
//            {
//                var jwtSecurityToken = await CreateJwtToken(user);
//                var token = new LoginDto
//                {
//                    UserId = user.Id,
//                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
//                };


//                return ResultDto<LoginDto>.Success(token);
//            }
//            else
//            {
//                return ResultDto<LoginDto>.Failure("Invalid login credentials.");
//            }
//        }

//        private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
//        {
//            var userClaims = await _userManager.GetClaimsAsync(user);
//            var roles = await _userManager.GetRolesAsync(user);
//            var roleClaims = new List<Claim>();

//            foreach (var role in roles)
//                roleClaims.Add(new Claim(ClaimTypes.Role, role));

//            var claims = new[]
//            {
//            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
//            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//            new Claim(JwtRegisteredClaimNames.Email, user.Email),
//            new Claim("uid", user.Id)
//        }
//            .Union(userClaims)
//            .Union(roleClaims);

//            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("lG0rDWELYD0jPtoLNlc/sMVREJMh8laXd5bvVEZzUeg="));
//            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

//            var jwtSecurityToken = new JwtSecurityToken(
//                issuer: "SecureApi",
//                audience: "SecureApiUser",
//                claims: claims,
//                expires: DateTime.Now.AddDays(30),
//                signingCredentials: signingCredentials);

//            return jwtSecurityToken;




//        }
//        //private static string Decrypt(string cipherText)
//        //{
//        //    string encryptionKey = "MAKV2SPBNI99212";
//        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
//        //    using (Aes encryptor = Aes.Create())
//        //    {
//        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
//        //        encryptor.Key = pdb.GetBytes(32);
//        //        encryptor.IV = pdb.GetBytes(16);
//        //        using (MemoryStream ms = new MemoryStream())
//        //        {
//        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
//        //            {
//        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
//        //                cs.Close();
//        //            }
//        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
//        //        }
//        //    }

//        //    return cipherText;
//        //}
//    }
//}
