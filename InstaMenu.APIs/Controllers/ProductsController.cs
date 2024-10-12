using InstaMenu.Application.Products.DTOs;
using InstaMenu.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstaMenu.APIs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> Get()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }
}
