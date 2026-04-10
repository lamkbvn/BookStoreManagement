using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Extensions;
using WebBanHang.Features.InventoryFeatures.Commands.DecreaseInventory;
using WebBanHang.Features.InventoryFeatures.Queries.GetInventories;
using WebBanHang.Features.InventoryFeatures.Queries.GetInventoryById;
using WebBanHang.Features.InventoryFeatures.Queries.GetInventoryByProductId;

namespace WebBanHang.Controllers;

[ApiController]
[Route("api/inventories")]
[Authorize(Roles = "Admin,Staff")]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetInventoriesQuery());
        return this.AutoResponse(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetInventoryByIdQuery { Id = id });
        return this.AutoResponse(result);
    }

    [HttpGet("product/{productId:int}")]
    public async Task<IActionResult> GetByProductId([FromRoute] int productId)
    {
        var result = await _mediator.Send(new GetInventoryByProductIdQuery { ProductId = productId });
        return this.AutoResponse(result);
    }

    [HttpPatch("{id:int}/decrease")]
    public async Task<IActionResult> Decrease([FromRoute] int id, [FromBody] DecreaseInventoryCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return this.AutoResponse(result);
    }
}

