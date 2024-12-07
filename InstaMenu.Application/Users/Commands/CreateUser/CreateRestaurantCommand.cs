using InstaMenu.Application.Common.Models;
using InstaMenu.Domain.Entities;
using MediatR;

namespace InstaMenu.Application.Restaurants.Commands.Create
{
    public class CreateRestaurantCommand : IRequest<ResultDto<object>>
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string PhoneNumber { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string AddressLink { get; set; }
        public string AddressAsText { get; set; }
        public string Logo { get; set; }
        public float MinimumOrder { get; set; }
        public float DeliveryFeePerKilometer { get; set; }

        public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, ResultDto<object>>
        {
            private static readonly List<Restaurant> _restaurants = new();

            public async Task<ResultDto<object>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
            {
                var restaurant = new Restaurant
                {
                    Id = _restaurants.Any() ? _restaurants.Max(r => r.Id) + 1 : 1,
                    Name = request.Name,
                    Slug = request.Slug,
                    PhoneNumber = request.PhoneNumber,
                    FacebookUrl = request.FacebookUrl,
                    InstagramUrl = request.InstagramUrl,
                    AddressLink = request.AddressLink,
                    AddressAsText = request.AddressAsText,
                    Logo = request.Logo,
                    MinimumOrder = request.MinimumOrder,
                    DeliveryFeePerKilometer = request.DeliveryFeePerKilometer,
                    CreatedAt = DateTime.UtcNow,
                    VisitCount = 0
                };

                _restaurants.Add(restaurant);

                return await Task.FromResult(ResultDto<object>.Success(new
                {
                    Message = "Restaurant created successfully.",
                    Result = new { restaurant.Id }
                }));
            }
        }
    }
}
