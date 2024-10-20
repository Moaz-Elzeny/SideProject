using InstaMenu.Application.Common.Models;
using InstaMenu.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace InstaMenu.Application.Users.Commands.EditUser
{
    public class EditUserCommand : IRequest<ResultDto<string>>
    {
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditUserCommandHandler : IRequestHandler<EditUserCommand, ResultDto<string>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IHostingEnvironment _environment;

            public EditUserCommandHandler(UserManager<AppUser> userManager, IHostingEnvironment environment)
            {
                _userManager = userManager;
                _environment = environment;
            }

            public async Task<ResultDto<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                if (user == null)
                    throw new NotFoundException("User not found");

                if (request.UserName != null)
                    user.UserName = request.UserName;

                if (request.Email != null)
                    user.Email = request.Email;

                if (request.Name != null)
                    user.Name = request.Name;

                //if (request.Password != null)
                //    user.PasswordHash = Encrypt(request.Password);

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return ResultDto<string>.Success("User updated successfully ✔️");
                }
                else
                {
                    return ResultDto<string>.Failure("Failed to update user");
                }
            }
            //private static string Encrypt(string clearText)
            //{
            //    string encryptionKey = "MAKV2SPBNI99212";
            //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            //    using (Aes encryptor = Aes.Create())
            //    {
            //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            //        encryptor.Key = pdb.GetBytes(32);
            //        encryptor.IV = pdb.GetBytes(16);
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
            //            {
            //                cs.Write(clearBytes, 0, clearBytes.Length);
            //                cs.Close();
            //            }
            //            clearText = Convert.ToBase64String(ms.ToArray());
            //        }
            //    }

            //    return clearText;
            //}
        }
    }
}
