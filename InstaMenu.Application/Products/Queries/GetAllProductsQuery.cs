using InstaMenu.Application.Products.DTOs;
using MediatR;

namespace InstaMenu.Application.Products.Queries
{
    public record GetAllProductsQuery() : IRequest<List<ProductDto>>;
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = new List<ProductDto>
        {
            new ProductDto(1, "Pizza"),
            new ProductDto(2, "Burger"),
            new ProductDto(3, "Pasta")
        };

            return await Task.FromResult(products); 
        }
    }
}
