using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.InventoryFeatures.Queries.GetInventoryByProductId;
using WebBanHang.Features.ProductFeatures.Commands.CreateProduct;
using WebBanHang.Features.ProductFeatures.Commands.DeleteProduct;
using WebBanHang.Features.ProductFeatures.Commands.UpdateProduct;
using WebBanHang.Features.ProductFeatures.Queries.GetProductById;
using WebBanHang.Features.ProductFeatures.Queries.GetProducts;

namespace WebBanHang.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetProductsQuery());
            return this.AutoResponse(result);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { Id = id });
            return this.AutoResponse(result);
        }

        [HttpGet("{id:int}/inventory")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> GetInventoryByProductId(int id)
        {
            var result = await _mediator.Send(new GetInventoryByProductIdQuery { ProductId = id });
            return this.AutoResponse(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return this.AutoResponse(result);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return this.AutoResponse(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand { Id = id });
            return this.AutoResponse(result);
        }
    }
}

