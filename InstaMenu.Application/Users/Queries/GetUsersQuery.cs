using InstaMenu.Application.Common.Models;
using InstaMenu.Application.Users.DTOs;
using InstaMenu.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InstaMenu.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<ResultDto<List<UserDto>>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ResultDto<List<UserDto>>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUsersQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResultDto<List<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            //var users = await _userManager.Users.ToListAsync();

            //var userDtos = users.Select(user => new UserDto
            //{
            //    UserId = user.Id,
            //    UserName = user.UserName,
            //    Email = user.Email,
            //    Name = user.Name,
            //    CreatedById = user.CreatedById,
            //    CreationDate = user.CreationDate,
            //    ModifiedById = user.ModifiedById,
            //    ModificationDate = user.ModificationDate,

            //}).ToList();
            var userDtos = new List<UserDto>();
            return ResultDto<List<UserDto>>.Success(userDtos);
        }       
    }

}
