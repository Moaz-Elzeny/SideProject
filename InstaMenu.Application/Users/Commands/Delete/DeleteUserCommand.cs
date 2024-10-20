﻿using InstaMenu.Application.Common.Models;
using InstaMenu.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace InstaMenu.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<ResultDto<Unit>>
    {
        public string UserId { get; set; }
        public string CurrentUserId { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultDto<Unit>>
        {
            private readonly UserManager<AppUser> _userManager;

            public DeleteUserCommandHandler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<ResultDto<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                if (user == null)
                {
                    throw new NotFoundException("User not found");
                }

                if (user.Id == request.CurrentUserId)
                {
                    return ResultDto<Unit>.Failure("Cannot delete your own user");
                }

                user.Deleted = true;
                user.ModifiedById = request.CurrentUserId;
                user.ModificationDate = DateTime.Now;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return ResultDto<Unit>.Success(Unit.Value);
                }
                else
                {
                    return ResultDto<Unit>.Failure("Failed to delete user");
                }
            }
        }
    }

}
