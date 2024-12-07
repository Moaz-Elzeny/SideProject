using InstaMenu.Application.Common.Models;
using InstaMenu.Domain.Entities;
using MediatR;

namespace InstaMenu.Application.Restaurants.Commands.Delete
{
    public class DeleteRestaurantCommand : IRequest<ResultDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }
        public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, ResultDto<object>>
        {
            private static readonly List<Restaurant> _restaurants = new();

            public async Task<ResultDto<object>> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
            {
                var restaurant = _restaurants.FirstOrDefault(r => r.Id == request.Id);
                if (restaurant == null)
                {
                    return ResultDto<object>.Failure("Restaurant not found.");
                }

                restaurant.Deleted = true;
                restaurant.ModificationDate = DateTime.Now;
                restaurant.ModifiedById = request.CurrentUserId;

                //_restaurants.SaveChanges();

                return await Task.FromResult(ResultDto<object>.Success(new { Message = "Restaurant deleted successfully." }));
            }
        }
    }
}
