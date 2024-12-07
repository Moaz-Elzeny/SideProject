using InstaMenu.Application.Common.Models;
using InstaMenu.Domain.Entities;
using MediatR;

namespace InstaMenu.Application.Users.Commands.EditUser
{
    public class UpdateRestaurantCommand : IRequest<ResultDto<object>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? AddressLink { get; set; }
        public string? AddressAsText { get; set; }
        public string? Logo { get; set; }
        public float? MinimumOrder { get; set; }
        public float? DeliveryFeePerKilometer { get; set; }

        public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, ResultDto<object>>
        {
            private static readonly List<Restaurant> _restaurants = new();

            public async Task<ResultDto<object>> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
            {
                var restaurant = _restaurants.FirstOrDefault(r => r.Id == request.Id);
                if (restaurant == null)
                {
                    return ResultDto<object>.Failure("Restaurant not found.");
                }

                restaurant.Name = request.Name;
                restaurant.Slug = request.Slug;
                restaurant.PhoneNumber = request.PhoneNumber;
                restaurant.FacebookUrl = request.FacebookUrl;
                restaurant.InstagramUrl = request.InstagramUrl;
                restaurant.AddressLink = request.AddressLink;
                restaurant.AddressAsText = request.AddressAsText;
                restaurant.Logo = request.Logo;
                restaurant.MinimumOrder = request.MinimumOrder.Value;
                restaurant.DeliveryFeePerKilometer = request.DeliveryFeePerKilometer.Value;

                return await Task.FromResult(ResultDto<object>.Success(new { Message = "Restaurant updated successfully." }));
            }
        }
    }
}
