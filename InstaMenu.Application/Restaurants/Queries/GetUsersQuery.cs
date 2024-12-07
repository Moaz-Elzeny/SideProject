using InstaMenu.Application.Common.Models;
using InstaMenu.Application.Restaurants.DTOs;
using InstaMenu.Domain.Entities;
using MediatR;
using Rigor.Application.Helpers;

namespace InstaMenu.Application.Restaurants.Queries
{
    public class GetAllRestaurantsQuery : IRequest<ResultDto<object>>
    {
        public int PageNumber { get; set; }
        public string? SearchKeyword { get; set; }
        public float? MinimumOrder { get; set; }
    }

    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, ResultDto<object>>
    {
        private static readonly List<Restaurant> _restaurants = new();

        public async Task<ResultDto<object>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            const int PageSize = 10;

            var query = _restaurants.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
            {
                query = query.Where(r =>
                    r.Name.Contains(request.SearchKeyword, StringComparison.OrdinalIgnoreCase) ||
                    r.Slug.Contains(request.SearchKeyword, StringComparison.OrdinalIgnoreCase));
            }

            if (request.MinimumOrder.HasValue)
            {
                query = query.Where(r => r.MinimumOrder >= request.MinimumOrder.Value);
            }

            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / PageSize);

            var restaurants = query
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .Select(r => new RestaurantListDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Slug = r.Slug,
                    PhoneNumber = r.PhoneNumber,
                    MinimumOrder = r.MinimumOrder,
                    DeliveryFeePerKilometer = r.DeliveryFeePerKilometer,
                    VisitCount = r.VisitCount
                })
                .ToList();

            var paginatedList = new PaginatedList<object>
            {
                Data = restaurants,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = PageSize,
                TotalPages = totalPages
            };

            return ResultDto<object>.Success(new { Data = paginatedList });
        }
    }

}
